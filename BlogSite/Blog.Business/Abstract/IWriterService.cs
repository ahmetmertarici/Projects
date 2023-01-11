using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Business.Abstract
{
    public interface IWriterService
    {
         #region Generics
        Task CreateAsync(Writer writer);
        Task<Writer> GetByIdAsync(int id);
        Task<List<Writer>> GetAllAsync();
        void Update(Writer writer);
        void Delete(Writer writer);
        #endregion

        int GetWriterId(string email);
        Task<Writer> GetTheWriterAsync(string username);

    }
}