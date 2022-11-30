using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreCompanyIntroductionRepository : EfCoreGenericRepository<CompanyIntroduction>, ICompanyIntroductionRepository
    {
        public EfCoreCompanyIntroductionRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }
    }
}
