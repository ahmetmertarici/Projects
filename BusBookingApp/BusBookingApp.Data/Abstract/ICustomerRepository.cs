using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Abstract
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task CreateAsync(Customer customer, int seatNumber, int id);
        Task<List<Customer>> CustomerListByTravelAsync(int id);

    }
}
