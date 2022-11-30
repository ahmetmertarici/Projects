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
    public class SupportManager : ISupportService
    {
        private ISupportRepository _supportRepository;

        public SupportManager(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;
        }

        public async Task CreateAsync(Support support)
        {
            await _supportRepository.CreateAsync(support);
        }

        public void Delete(Support support)
        {
            _supportRepository.Delete(support);
        }

        public async Task<List<Support>> GetAllAsync()
        {
            return await _supportRepository.GetAllAsync();
        }

        public async Task<Support> GetByIdAsync(int id)
        {
            return await _supportRepository.GetByIdAsync(id);
        }

        public List<Support> GetSupportMessages(string email)
        {
            return _supportRepository.GetSupportMessages(email);
        }

        public List<Support> ShowUnreadMessages()
        {
            return _supportRepository.ShowUnreadMessages();
        }

        public void Update(Support support)
        {
            _supportRepository.Update(support);
        }
    }
}
