using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreCustomerRepository : EfCoreGenericRepository<Customer>, ICustomerRepository
    {
        public EfCoreCustomerRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }
        public async Task CreateAsync(Customer customer, int seatNumber, int id)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            var ticket=context.Tickets
                .Select(ticket => new Ticket
                {
                    CustomerId = customer.CustomerId,
                    TravelDetailId = id,
                    SeatNumber = seatNumber
                }).FirstOrDefault();
            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
        }

        public async Task<List<Customer>> CustomerListByTravelAsync(int id)
        {
            var a= await context
                .Customers
                .Where(c=>c.Ticket.TravelDetailId==id)
                .Include(c=>c.Ticket)
                .ToListAsync();
            return a;
        }
    }
}
