using BusBookingApp.Business.Abstract;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Customer customer, int seatNumber, int id)
        {
            await _customerRepository.CreateAsync(customer, seatNumber, id);
        }

        public async Task<List<Customer>> CustomerListByTravelAsync(int id)
        {
            return await _customerRepository.CustomerListByTravelAsync(id);
        }

        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return _customerRepository.GetByIdAsync(id);
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
