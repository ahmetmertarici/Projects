using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Entity
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int CustomerId { get; set; }
        public int TravelDetailId { get; set; }
        public int SeatNumber { get; set; }


        public TravelDetail TravelDetail { get; set; }
        public Customer Customer { get; set; }
    }
}