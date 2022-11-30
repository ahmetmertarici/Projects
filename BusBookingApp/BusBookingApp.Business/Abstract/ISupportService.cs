using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ISupportService
    {
        Task CreateAsync(Support support);
        Task<Support> GetByIdAsync(int id);
        Task<List<Support>> GetAllAsync();
        void Update(Support support);
        void Delete(Support support);

        List<Support> ShowUnreadMessages();
        List<Support> GetSupportMessages(string email);


    }
}
