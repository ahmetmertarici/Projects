using BusBookingApp.Business.Abstract;
using BusBookingApp.Core;
using BusBookingApp.Entity;
using BusBookingApp.Web.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingApp.Web.Controllers
{
    public class TicketController : Controller
    {
        private ITicketService _ticketService;
        private IBusService _busService;
        private ICustomerService _customerService;
        private ITravelDetailService _travelDetailService;

        public TicketController(ITicketService ticketService, IBusService busService, ICustomerService customerService, ITravelDetailService travelDetailService = null)
        {
            _ticketService = ticketService;
            _busService = busService;
            _customerService = customerService;
            _travelDetailService = travelDetailService;
        }

        public async Task<IActionResult> ExpeditionReservation(int id)
        {
            List<int> seatNumbers = new List<int>(); //listelenecek koltuklar
            int seats = _busService.GetSeatCapacity(id); //ilgili otobüsün kapasitesi 
            ViewBag.Seats = seats; 
            List<int> fullSeat = _ticketService.GetFullSeat(id); //dolu koltuklar
            ViewBag.FullSeat = fullSeat;
            for (int i = 1; i <= seats; i++)
            {
                seatNumbers.Add(i);
            }
            foreach (var item in fullSeat)
            {
                seatNumbers.Remove(item);
            }
            ViewBag.SeatNumbers = seatNumbers;
            ExpeditionReservationModel expeditionReservationModel = new()
            {
                TravelDetail = await _travelDetailService.GetByIdTravelDetailAsync(id)
            };
            return View(expeditionReservationModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExpeditionReservation(ExpeditionReservationModel expeditionReservationModel, int seatNumber, int id)
        {
            if (ModelState.IsValid && seatNumber!=null)
            {
                Customer customer = new Customer()
                {
                    CustomerName = expeditionReservationModel.CustomerName,
                    CustomerSurname = expeditionReservationModel.CustomerSurname,
                    PhoneNumber = expeditionReservationModel.PhoneNumber,
                    Email = expeditionReservationModel.Email 
                };
                await _customerService.CreateAsync(customer, seatNumber, id);
                return RedirectToAction("CheckOut");
            }
            return RedirectToAction("ExpeditionReservation");
        }

        public async Task<IActionResult> CheckOut()
        {
            //var travelDetail = await _travelDetailService.GetByIdTravelDetailAsync(id);
            //PaymentModel paymentModel = new();
            //paymentModel.TravelDetail = new TravelDetail()
            //{
            //    Price = travelDetail.Price
            //};
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(PaymentModel paymentModel, int id)
        {
            var travelDetail = await _travelDetailService.GetByIdTravelDetailAsync(id);
            paymentModel.TravelDetail = new TravelDetail()
            {
                Price = travelDetail.Price
            };
            if (ModelState.IsValid)
            {
                var payment = PaymentProcess(paymentModel);
                if (payment.Status == "success")
                {
                    TempData["Message"] = Jobs.CreateMessage("BAŞARILI!", "Ödemeniz başarıyla alınmıştır!", "success");
                    return View("Success");
                }
                else
                {
                    TempData["Message"] = Jobs.CreateMessage("BAŞARISIZ!", payment.ErrorMessage, "danger");
                }
            }
            return View(paymentModel);
        }

        private Payment PaymentProcess(PaymentModel paymentModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-4F90KTu5eqyD0lyrUAyDhFYbiBrxBglz";
            options.SecretKey = "sandbox-YnPvkVeJ6QvICLxwLHi8nkYVIiAziFRN";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = paymentModel.TravelDetail.Price.ToString();
            request.PaidPrice = paymentModel.TravelDetail.Price.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            //paymentCard.CardHolderName = paymentModel.CardName;
            paymentCard.CardNumber = paymentModel.CardNumber;
            paymentCard.ExpireMonth = paymentModel.ExpirationMonth;
            paymentCard.ExpireYear = paymentModel.ExpirationYear;
            paymentCard.Cvc = paymentModel.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = paymentModel.FirstName;
            buyer.Surname = paymentModel.LastName;
            buyer.GsmNumber = paymentModel.Phone;
            buyer.Email = paymentModel.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = paymentModel.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = paymentModel.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            return Payment.Create(request, options);

        }
        public async Task<IActionResult> CompletedReservation()
        {
            return View();
        }
    }
}
