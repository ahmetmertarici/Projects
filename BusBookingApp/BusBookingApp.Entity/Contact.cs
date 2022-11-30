using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string BranchName { get; set; }
        public string BranchPhone { get; set; }
        public string BranchAddress { get; set; }
    }
}
