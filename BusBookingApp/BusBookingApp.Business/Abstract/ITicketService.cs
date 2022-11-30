using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ITicketService
    {
        #region Generics
        Task CreateAsync(Ticket ticket);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync();
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
        #endregion
        List<int> GetFullSeat(int id);

    }
}