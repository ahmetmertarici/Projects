using BusBookingApp.Entity;

namespace BusBookingApp.Web.Models
{
    public class ExpeditionListModel
    {
        public int TravelDetailId { get; set; }
        public int DepartureCityId { get; set; }
        public City DepartureCity { get; set; }
        public int ArrivalCityId { get; set; }
        public City ArrivalCity { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }

    }
}
