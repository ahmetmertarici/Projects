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
    public class ContactManager : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateAsync(Contact contact)
        {
            await _contactRepository.CreateAsync(contact);
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }
    }
}
