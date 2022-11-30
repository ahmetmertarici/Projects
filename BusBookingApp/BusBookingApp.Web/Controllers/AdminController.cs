using BusBookingApp.Business.Abstract;
using BusBookingApp.Core;
using BusBookingApp.Entity;
using BusBookingApp.Web.Identity;
using BusBookingApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private ITicketService _ticketService;
        private IBusService _busService;
        private ICustomerService _customerService;
        private ICityService _cityService;
        private ITravelDetailService _travelDetailService;
        private IContactService _contactService;
        private ICompanyIntroductionService _companyIntroduction;
        private ISupportService _supportService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ITicketService ticketService, IBusService busService, ICustomerService customerService, ICityService cityService, ITravelDetailService travelDetailService, UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IContactService contactService, ICompanyIntroductionService companyIntroduction, ISupportService supportService)
        {
            _ticketService = ticketService;
            _busService = busService;
            _customerService = customerService;
            _cityService = cityService;
            _travelDetailService = travelDetailService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _contactService = contactService;
            _companyIntroduction = companyIntroduction;
            _supportService = supportService;
        }
        #region UserActions
        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            return View(userList);
        }
        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            _userManager.DeleteAsync(user);
            return RedirectToAction("UserList");
        }
        public async Task<IActionResult> UserCreate()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!", "success");
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return RedirectToAction("UserList"); }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        userModel.SelectedRoles = userModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, userModel.SelectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userModel.SelectedRoles).ToArray<string>());
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("UserList");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                    return View(userModel);
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Böyle bir kullanıcı bulunamadı!", "danger");
            }
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> ChangeUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            var userPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, userPassToken, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
                return RedirectToAction("UserList");
            }
            return View(changePasswordModel);
        }
        #endregion
        //*******************************************************************************************
        #region RoleActions
        public async Task<IActionResult> RoleList()
        {
            var roleList = await _roleManager.Roles.ToListAsync();
            return View(roleList);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleModel.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Role başarıyla oluşturuldu.", "success");
                    return RedirectToAction("RoleList");
                }
            }
            return View(roleModel);
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Silme Başarısız oldu!", "Bu rolde userlar bulunmaktadır, önce userları silmeniz gerekmektedir.", "danger");
                    return RedirectToAction("RoleList");
                }
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Silme işlemi tamamlandı.", "success");
            }
            return RedirectToAction("RoleList");
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var users = await _userManager.Users.ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<MyIdentityUser>();
            var nonMembers = new List<MyIdentityUser>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            RoleDetails roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect($"/Admin/RoleEdit/{roleEditModel.RoleId}");
        }

        #endregion
        //*******************************************************************************************

        public async Task<IActionResult> ListRoutes()
        {
            RoutesListModel routesListModel = new RoutesListModel()
            {
                TravelDetails = await _travelDetailService.GetAllTravelDetailAsync()
            };
            return View(routesListModel);
        }
        public async Task<IActionResult> CreateRoute()
        {
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.Buses = await _busService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteModel createRouteModel)
        {
            if (ModelState.IsValid)
            {
                TravelDetail travelDetail = new()
                {
                    DepartureCityId = createRouteModel.DepartureCityId,
                    ArrivalCityId = createRouteModel.ArrivalCityId,
                    Date = createRouteModel.Date.ToString("yyyy-MM-dd"),
                    Time = createRouteModel.Time,
                    Price = createRouteModel.Price,
                    PeronNumber = createRouteModel.PeronNumber,
                    BusId = createRouteModel.BusId
                };
                await _travelDetailService.CreateAsync(travelDetail);
                return RedirectToAction("ListRoutes");
            }
            
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.Buses = await _busService.GetAllAsync();
            return View(createRouteModel);
        }
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var entity = await _travelDetailService.GetByIdAsync(id);
            _travelDetailService.Delete(entity);
            return RedirectToAction("ListRoutes");
        }
        public async Task<IActionResult> EditRoute(int id)
        {
            ViewBag.Cities = await _cityService.GetAllAsync();
            ViewBag.Buses = await _busService.GetAllAsync();
            var travelDetail = await _travelDetailService.GetByIdAsync(id);
            EditRouteModel editRouteModel = new()
            {
                id = travelDetail.TravelDetailId,
                DepartureCityId = travelDetail.DepartureCityId,
                ArrivalCityId = travelDetail.ArrivalCityId,
                Date = travelDetail.Date,
                Time = travelDetail.Time,
                PeronNumber = travelDetail.PeronNumber,
                BusId = travelDetail.BusId,
                Price = travelDetail.Price
            };
            return View(editRouteModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditRoute(EditRouteModel editRouteModel)
        {
            if (ModelState.IsValid)
            {
                var travelDetail = await _travelDetailService.GetByIdAsync(editRouteModel.id);

                travelDetail.DepartureCityId = editRouteModel.DepartureCityId;
                travelDetail.ArrivalCityId = editRouteModel.ArrivalCityId;
                travelDetail.Date = editRouteModel.Date;
                travelDetail.Time = editRouteModel.Time;
                travelDetail.Price = editRouteModel.Price;
                travelDetail.PeronNumber = editRouteModel.PeronNumber;
                travelDetail.BusId = editRouteModel.BusId;

                _travelDetailService.Update(travelDetail);
                return RedirectToAction("ListRoutes");
            }
            return View(editRouteModel);
        }
        public async Task<IActionResult> CustomerListByTravel(int id)
        {
            var customerList = await _customerService.CustomerListByTravelAsync(id);
            var x = customerList

            .Select(x => new CustomerListModel()
            {
                CustomerName = x.CustomerName,
                CustomerSurname = x.CustomerSurname,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                SeatNumber = x.Ticket.SeatNumber
            });
            return View(customerList);
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            _customerService.Delete(customer);
            return RedirectToAction("ListRoutes");
        }

        //**************************************************************

        public async Task<IActionResult> ListCities()
        {
            var cities = await _cityService.GetAllAsync();
            return View(cities);
        }
        public async Task<IActionResult> DeleteCity(int id)
        {
            var entity = await _cityService.GetByIdAsync(id);
            _cityService.Delete(entity);
            return RedirectToAction("ListCities");
        }
        public async Task<IActionResult> CreateCity()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityModel createCityModel)
        {
            if (ModelState.IsValid)
            {
                City city = new()
                {
                    CityName = createCityModel.CityName
                };
                await _cityService.CreateAsync(city);
                return RedirectToAction("ListCities");
            }
            return View(createCityModel);
        }
        //**************************************************************
        public async Task<IActionResult> ListBuses()
        {
            var buses = await _busService.GetAllAsync();
            return View(buses);
        }
        public async Task<IActionResult> DeleteBus(int id)
        {
            var entity = await _busService.GetByIdAsync(id);
            _busService.Delete(entity);
            return RedirectToAction("ListBuses");
        }
        public async Task<IActionResult> CreateBus()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBus(CreateBusModel createBusModel)
        {
            if (ModelState.IsValid)
            {
                Bus bus = new()
                {
                    BusSeatCapacity = createBusModel.BusSeatCapacity
                };
                await _busService.CreateAsync(bus);
                return RedirectToAction("ListBuses");
            }
            return View(createBusModel);
        }
        //*********************************************************************
        public async Task<IActionResult> ContactList()
        {
            var contacts = await _contactService.GetAllAsync();
            return View(contacts);
        }

        public async Task<IActionResult> CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactModel createContactModel)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new()
                {
                    BranchName = createContactModel.BranchName,
                    BranchPhone = createContactModel.BranchPhone,
                    BranchAddress = createContactModel.BranchAddress
                };
                await _contactService.CreateAsync(contact);
                return RedirectToAction("ContactList");
            }
            return View(createContactModel);
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var entity = await _contactService.GetByIdAsync(id);
            _contactService.Delete(entity);
            return RedirectToAction("ContactList");
        }

        public async Task<IActionResult> EditContact(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            EditContactModel editContactModel = new()
            {
                id = contact.ContactId,
                BranchName = contact.BranchName,
                BranchPhone = contact.BranchPhone,
                BranchAddress = contact.BranchAddress
            };
            return View(editContactModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(EditContactModel editContactModel)
        {
            if (ModelState.IsValid)
            {
                var contact = await _contactService.GetByIdAsync(editContactModel.id);

                contact.BranchName = editContactModel.BranchName;
                contact.BranchPhone = editContactModel.BranchPhone;
                contact.BranchAddress = editContactModel.BranchAddress;

                _contactService.Update(contact);
                return RedirectToAction("ContactList");
            }
            return View(editContactModel);
        }
        //********************************************************************
        public async Task<IActionResult> CompanyIntroductionList()
        {
            var companyIntroductions = await _companyIntroduction.GetAllAsync();
            return View(companyIntroductions);
        }

        public async Task<IActionResult> CreateCompanyIntroduction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyIntroduction(CreateCompanyIntroductionModel createCompanyIntroductionModel)
        {
            if (ModelState.IsValid)
            {
                CompanyIntroduction companyIntroduction = new()
                {
                    CompanyDescriptionTitle = createCompanyIntroductionModel.CompanyDescriptionTitle,
                    CompanyDescription = createCompanyIntroductionModel.CompanyDescription
                };
                await _companyIntroduction.CreateAsync(companyIntroduction);
                return RedirectToAction("CompanyIntroductionList");
            }
            return View(createCompanyIntroductionModel);
        }
        public async Task<IActionResult> DeleteCompanyIntroduction(int id)
        {
            var entity = await _companyIntroduction.GetByIdAsync(id);
            _companyIntroduction.Delete(entity);
            return RedirectToAction("CompanyIntroductionList");
        }

        //********************************************************************
        public async Task<IActionResult> SupportList()
        {
            var supports = await _supportService.GetAllAsync();
            return View(supports);
        }
        public async Task<IActionResult> AnswerSupport(int id)
        {
            var answer = await _supportService.GetByIdAsync(id);
            AnswerSupportModel answerSupportModel = new()
            {
                FirstName = answer.FirstName,
                LastName = answer.LastName,
                Email = answer.Email,
                PhoneNumber = answer.PhoneNumber,
                Topic = answer.Topic,
                Text = answer.Text
            };
            return View(answerSupportModel);
        }
        [HttpPost]
        public async Task<IActionResult> AnswerSupport(AnswerSupportModel answerSupportModel)
        {
            var answer = await _supportService.GetByIdAsync(answerSupportModel.id);

            answer.Answer=answerSupportModel.Answer;
            _supportService.Update(answer);

            return RedirectToAction("SupportList");
        }
        public async Task<IActionResult> DeleteSupport(int id)
        {
            var entity = await _supportService.GetByIdAsync(id);
            _supportService.Delete(entity);
            return RedirectToAction("SupportList");
        }
    
        public async Task<IActionResult> ShowUnreadMessages()
        {
            var showUnreadMessages = _supportService.ShowUnreadMessages();
            return View(showUnreadMessages);
        }
    }
}
