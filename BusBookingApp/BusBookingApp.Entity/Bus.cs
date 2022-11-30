using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class Bus
    {
        public int BusId { get; set; }
        public int BusSeatCapacity { get; set; }

        public List<TravelDetail> Travels { get; set; }
    }
}