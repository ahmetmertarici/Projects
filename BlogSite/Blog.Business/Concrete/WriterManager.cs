using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entity;

namespace Blog.Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private IWriterRepository _writerRepository;

        public WriterManager(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public async Task CreateAsync(Writer writer)
        {
            await _writerRepository.CreateAsync(writer);
        }

        public void Delete(Writer writer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Writer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Writer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Writer> GetTheWriterAsync(string username)
        {
            return await _writerRepository.GetTheWriterAsync(username);
        }

        public int GetWriterId(string email)
        {
            return _writerRepository.GetWriterId(email);
        }

        public void Update(Writer writer)
        {
            _writerRepository.Update(writer);
        }
    }
}