using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Business.Abstract;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;

namespace BusBookingApp.Business.Concrete
{
    public class TicketManager: ITicketService
    {
        private ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task CreateAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> GetFullSeat(int id)
        {
            return _ticketRepository.GetFullSeat(id);
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}