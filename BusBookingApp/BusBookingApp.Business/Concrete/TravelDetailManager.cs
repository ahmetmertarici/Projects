using BusBookingApp.Business.Abstract;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Concrete
{
    public class TravelDetailManager : ITravelDetailService
    {
        private ITravelDetailRepository _travelDetailRepository;

        public TravelDetailManager(ITravelDetailRepository travelDetailRepository)
        {
            _travelDetailRepository = travelDetailRepository;
        }

        public Task CreateAsync(TravelDetail travelDetail)
        {
            return _travelDetailRepository.CreateAsync(travelDetail);
        }

        public void Delete(TravelDetail travelDetail)
        {
             _travelDetailRepository.Delete(travelDetail);
        }

        public async Task<List<TravelDetail>> GetAllAsync()
        {
            return await _travelDetailRepository.GetAllAsync();
        }

        public async Task<List<TravelDetail>> GetAllTravelDetailAsync()
        {
            return await _travelDetailRepository.GetAllTravelDetailAsync();
        }

        public async Task<TravelDetail> GetByIdAsync(int id)
        {
            return await _travelDetailRepository.GetByIdAsync(id);
        }

        public async Task<TravelDetail> GetByIdTravelDetailAsync(int id)
        {
            return await _travelDetailRepository.GetByIdTravelDetailAsync(id);
        }

        public async Task<List<TravelDetail>> GetExpeditionListAsync(int departureId, int arrivalId, DateTime date)
        {
            return await _travelDetailRepository.GetExpeditionListAsync(departureId, arrivalId, date);
        }

        public void Update(TravelDetail travelDetail)
        {
            _travelDetailRepository.Update(travelDetail);
        }
    }
}
