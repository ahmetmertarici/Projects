using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreCityRepository:EfCoreGenericRepository<City>,ICityRepository
    {
        public EfCoreCityRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }
    }
}