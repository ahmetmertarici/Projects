using Blog.Data.Abstract;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreToDoListRepository : EfCoreGenericRepository<ToDoList>, IToDoListRepository
    {
        public EfCoreToDoListRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }
    }
}
