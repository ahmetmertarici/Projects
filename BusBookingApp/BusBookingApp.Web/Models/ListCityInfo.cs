using BusBookingApp.Entity;

namespace BusBookingApp.Web.Models
{
    public class ListCityInfo
    {
        public List<City> Cities { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public DateTime Date { get; set; }
    }
}
