using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Ticket Ticket { get; set; }
    }
}
