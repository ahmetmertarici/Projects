using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Abstract
{
    public interface ITravelDetailRepository : IRepository<TravelDetail>
    {
        Task<List<TravelDetail>> GetExpeditionListAsync(int departureId, int arrivalId, DateTime date);
        Task<List<TravelDetail>> GetAllTravelDetailAsync();
        Task<TravelDetail> GetByIdTravelDetailAsync(int id);
        Task<TravelDetail> GetPriceAsync(int id);
    }
}
