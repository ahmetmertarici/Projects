using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Data.Abstract
{
    public interface IWriterRepository: IRepository<Writer>
    {
        int GetWriterId(string email);
        Task<Writer> GetTheWriterAsync(string username);

    }
}