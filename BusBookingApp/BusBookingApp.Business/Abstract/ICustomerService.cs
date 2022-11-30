using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ICustomerService
    {
        #region Generics
        Task CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        void Update(Customer customer);
        void Delete(Customer customer);
        #endregion
        Task CreateAsync(Customer customer, int seatNumber, int id);
        Task<List<Customer>> CustomerListByTravelAsync(int id);
    }
}
