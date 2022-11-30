using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Entity;

namespace BusBookingApp.Data.Abstract
{
    public interface ITicketRepository:IRepository<Ticket>
    {
        List<int> GetFullSeat(int id);

    }
}