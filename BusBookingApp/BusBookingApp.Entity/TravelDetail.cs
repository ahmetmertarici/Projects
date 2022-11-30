using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class TravelDetail
    {
        public int TravelDetailId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public int PeronNumber { get; set; }
        public int DepartureCityId { get; set; }
        [ForeignKey("DepartureCityId")]
        public City DepartureCity { get; set; }
        public int ArrivalCityId { get; set; }
        [ForeignKey("ArrivalCityId")]
        public City ArrivalCity { get; set; }
        public int BusId { get; set; }


        public List<Ticket> Tickets { get; set; }
        public Bus Bus { get; set; }
    }
}
