using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class Support
    {
        public int SupportId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string? Answer { get; set; }
    }
}
