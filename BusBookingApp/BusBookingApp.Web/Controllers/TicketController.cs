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
            List<int> seatNumbers = new List<int>(); 
            int seats = _busService.GetSeatCapacity(id); 
            ViewBag.Seats = seats; 
            List<int> fullSeat = _ticketService.GetFullSeat(id); 
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
            var travelDetail = await _travelDetailService.GetByIdTravelDetailAsync(id);
            expeditionReservationModel.TravelDetail = new TravelDetail()
            {
                DepartureCity = travelDetail.DepartureCity,
                ArrivalCity = travelDetail.ArrivalCity,
                Date = travelDetail.Date,
                Time=travelDetail.Time,
                Price = travelDetail.Price
            };
            if (ModelState.IsValid && seatNumber != 0)
            {
                var payment = PaymentProcess(expeditionReservationModel);
                if (payment.Status == "success")
                {
                    Customer customer = new Customer()
                    {
                        CustomerName = expeditionReservationModel.CustomerName,
                        CustomerSurname = expeditionReservationModel.CustomerSurname,
                        PhoneNumber = expeditionReservationModel.PhoneNumber,
                        Email = expeditionReservationModel.Email
                    };
                    await _customerService.CreateAsync(customer, seatNumber, id);
                    TempData["AlertMessage"] = Jobs.CreateMessage("BAŞARILI!", "Ödemeniz başarıyla alınmıştır!", "success");
                    return RedirectToAction("CompletedReservation"); 
                }
                else
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("BAŞARISIZ!", payment.ErrorMessage, "danger");
                }
            }
            List<int> seatNumbers = new List<int>(); 
            int seats = _busService.GetSeatCapacity(id);  
            ViewBag.Seats = seats;
            List<int> fullSeat = _ticketService.GetFullSeat(id); 
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
            return View(expeditionReservationModel);
        }
        public async Task<IActionResult> CompletedReservation()
        {
            return View();
        }
        private Payment PaymentProcess(ExpeditionReservationModel expeditionReservationModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-4F90KTu5eqyD0lyrUAyDhFYbiBrxBglz";
            options.SecretKey = "sandbox-YnPvkVeJ6QvICLxwLHi8nkYVIiAziFRN";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = expeditionReservationModel.TravelDetail.Price.ToString();
            request.PaidPrice = expeditionReservationModel.TravelDetail.Price.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = expeditionReservationModel.CardHolderName;
            paymentCard.CardNumber = expeditionReservationModel.CardNumber;
            paymentCard.ExpireMonth = expeditionReservationModel.ExpirationMonth;
            paymentCard.ExpireYear = expeditionReservationModel.ExpirationYear;
            paymentCard.Cvc = expeditionReservationModel.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = expeditionReservationModel.CustomerName;
            buyer.Surname = expeditionReservationModel.CustomerSurname;
            buyer.GsmNumber = expeditionReservationModel.PhoneNumber;
            buyer.Email = expeditionReservationModel.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul";
            buyer.Ip = "85.34.78.112";
            buyer.City = "İstanbul";
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

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = expeditionReservationModel.TravelDetail.Price.ToString();
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            return Payment.Create(request, options);
        }
    }
}
