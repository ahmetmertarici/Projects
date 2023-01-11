using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreWriterRepository: EfCoreGenericRepository<Writer>, IWriterRepository
    {
        public EfCoreWriterRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }

        public async Task<Writer> GetTheWriterAsync(string username)
        {
            return await context
                .Writers
                .Where(w => w.Nickname == username)
                .FirstOrDefaultAsync();
        }

        public int GetWriterId(string email)
        {
            return context
                .Writers
                .Where(w=>w.Mail==email)
                .Select(w=>w.WriterId)
                .FirstOrDefault();
        }
    }
}