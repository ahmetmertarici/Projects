using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Entity;

namespace BusBookingApp.Web.Models
{
    public class CompletedReservationModel
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}