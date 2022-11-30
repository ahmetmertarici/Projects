using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Abstract
{
    public interface ISupportRepository : IRepository<Support>
    {
        List<Support> ShowUnreadMessages();
        List<Support> GetSupportMessages(string email);
    }
}
