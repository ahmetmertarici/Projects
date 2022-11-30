using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ICityService
    {
        #region Generics
        Task CreateAsync(City city);
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetAllAsync();
        void Update(City city);
        void Delete(City city);
        #endregion

    }
}