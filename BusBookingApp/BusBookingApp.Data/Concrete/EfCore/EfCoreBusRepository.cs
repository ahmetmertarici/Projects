using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreBusRepository: EfCoreGenericRepository<Bus>, IBusRepository
    {
        public EfCoreBusRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }


        public int GetSeatCapacity(int id)
        {
            var sonuc = context
                .TravelDetails
                .Where(td => td.TravelDetailId == id)
                .Include(td => td.Bus)
                .FirstOrDefault();
            return sonuc.Bus.BusSeatCapacity;
                
        }
    }
}