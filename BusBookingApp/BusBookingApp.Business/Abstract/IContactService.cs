using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface IContactService
    {
        Task CreateAsync(Contact contact);
        Task<Contact> GetByIdAsync(int id);
        Task<List<Contact>> GetAllAsync();
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
