using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface IBusService
    {
        #region Generics
        Task CreateAsync(Bus bus);
        Task<Bus> GetByIdAsync(int id);
        Task<List<Bus>> GetAllAsync();
        void Update(Bus bus);
        void Delete(Bus bus);
        #endregion
        int GetSeatCapacity(int id);
    }
}