using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApp.Data.Concrete.EfCore
{
    public class EfCoreTicketRepository: EfCoreGenericRepository<Ticket>, ITicketRepository
    {
        public EfCoreTicketRepository(BusBookingContext _dbContext) : base(_dbContext)
        {

        }

        private BusBookingContext context
        {
            get { return _dbContext as BusBookingContext; }
        }

        public List<int> GetFullSeat(int id)
        {
            return context.Tickets
                .Where(i=>i.TravelDetailId==id)
                .Select(i=>i.SeatNumber)
                .ToList();
        }
    }
}