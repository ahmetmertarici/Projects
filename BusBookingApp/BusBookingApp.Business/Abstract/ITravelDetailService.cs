using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ITravelDetailService
    {
        #region Generics
        Task CreateAsync(TravelDetail travelDetail);
        Task<TravelDetail> GetByIdAsync(int id);
        Task<List<TravelDetail>> GetAllAsync();
        void Update(TravelDetail travelDetail);
        void Delete(TravelDetail travelDetail);
        #endregion

        Task<List<TravelDetail>> GetExpeditionListAsync(int departureId, int arrivalId, DateTime date);
        Task<List<TravelDetail>> GetAllTravelDetailAsync();
        Task<TravelDetail> GetByIdTravelDetailAsync(int id);
    }
}
