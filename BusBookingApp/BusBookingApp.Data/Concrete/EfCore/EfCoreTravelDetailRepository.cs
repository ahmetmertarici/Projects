using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreTravelDetailRepository : EfCoreGenericRepository<TravelDetail>, ITravelDetailRepository
    {
        public EfCoreTravelDetailRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }

        public async Task<List<TravelDetail>> GetAllTravelDetailAsync()
        {
            return await context 
                .TravelDetails
                .Include(td => td.DepartureCity)
                .Include(td => td.ArrivalCity)
                .ToListAsync();
        }

        public async Task<TravelDetail> GetByIdTravelDetailAsync(int id)
        {
            return await context
                .TravelDetails
                .Where(td=>td.TravelDetailId==id)
                .Include(td => td.DepartureCity)
                .Include(td => td.ArrivalCity)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TravelDetail>> GetExpeditionListAsync(int departureId, int arrivalId, DateTime date)
        {
            string dateTimeLocal = date.ToString("yyyy-MM-dd");
            return await context
                .TravelDetails
                .Where(td=>td.ArrivalCityId == arrivalId && td.DepartureCityId == departureId && td.Date==dateTimeLocal)
                .Include(td => td.DepartureCity)
                .Include(td => td.ArrivalCity)
                .ToListAsync();
        }
    }
}
