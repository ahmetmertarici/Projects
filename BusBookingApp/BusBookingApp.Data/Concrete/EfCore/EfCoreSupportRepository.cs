using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreSupportRepository : EfCoreGenericRepository<Support>, ISupportRepository
    {
        public EfCoreSupportRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }

        public List<Support> GetSupportMessages(string email)
        {
            return context
                .Supports
                .Where(x => x.Email == email)
                .ToList();
        }

        public List<Support> ShowUnreadMessages()
        {
            return context
                .Supports
                .Where(s => s.Answer == null)
                .ToList();
        }
    }
}
