using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusBookingApp.Web.Models;
using BusBookingApp.Business.Abstract;
using BusBookingApp.Entity;

namespace BusBookingApp.Web.Controllers;

public class HomeController : Controller
{
    private ICityService _cityService;
    private ITravelDetailService _travelDetailService;
    private ICompanyIntroductionService _companyIntroductionService;
    private IContactService _contactService;
    private ISupportService _supportService;

    public HomeController(ICityService cityService, ITravelDetailService travelDetailService, ICompanyIntroductionService companyIntroductionService, IContactService contactService, ISupportService supportService)
    {
        _cityService = cityService;
        _travelDetailService = travelDetailService;
        _companyIntroductionService = companyIntroductionService;
        _contactService = contactService;
        _supportService = supportService;
    }
    public async Task<IActionResult> Index()
    {
        ListCityInfo listCityInfo = new ListCityInfo()
        {
            Cities =await _cityService.GetAllAsync(),
        };
        return View(listCityInfo);
    }
    public async Task<IActionResult> ExpeditionList(int departureId, int arrivalId, DateTime date)
    {
        ViewBag.Cities = await _cityService.GetAllAsync();
        var expeditionList = await _travelDetailService.GetExpeditionListAsync(departureId, arrivalId, date);
        List<ExpeditionListModel> expeditionListModels = new();
        foreach (var expedition in expeditionList)
        {
            ExpeditionListModel expeditionListModel = new ExpeditionListModel()
            {
                TravelDetailId = expedition.TravelDetailId,
                Date = expedition.Date,
                DepartureCityId = expedition.DepartureCityId,
                ArrivalCityId = expedition.ArrivalCityId,
                Time = expedition.Time,
                Price = expedition.Price,
                DepartureCity = expedition.DepartureCity,
                ArrivalCity=expedition.ArrivalCity
            };
            expeditionListModels.Add(expeditionListModel);
        }
        return View(expeditionListModels);
    }

    public async Task<IActionResult> ContactList()
    {
        var contacts = await _contactService.GetAllAsync();
        return View(contacts);
    }

    public async Task<IActionResult> CompanyIntroductionList()
    {
        var companyIntroduction = await _companyIntroductionService.GetAllAsync();
        return View(companyIntroduction);
    }

    public IActionResult Support()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Support(SupportModel supportModel)
    {
        if (ModelState.IsValid)
        {
            Support support = new()
            {
                FirstName = supportModel.FirstName,
                LastName = supportModel.LastName,
                Email = supportModel.Email,
                PhoneNumber = supportModel.PhoneNumber,
                Topic = supportModel.Topic,
                Text = supportModel.Text
            };
            await _supportService.CreateAsync(support);
            return RedirectToAction("Index");
        }
        return View(supportModel);
    }
    

}
