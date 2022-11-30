using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingApp.Business.Abstract;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;

namespace BusBookingApp.Business.Concrete
{
    public class BusManager: IBusService
    {
        private IBusRepository _busRepository;

        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task CreateAsync(Bus bus)
        {
            await _busRepository.CreateAsync(bus);
        }

        public void Delete(Bus bus)
        {
            _busRepository.Delete(bus);
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _busRepository.GetAllAsync();
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _busRepository.GetByIdAsync(id);
        }

        public int GetSeatCapacity(int id)
        {
            return _busRepository.GetSeatCapacity(id);
        }

        public void Update(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}