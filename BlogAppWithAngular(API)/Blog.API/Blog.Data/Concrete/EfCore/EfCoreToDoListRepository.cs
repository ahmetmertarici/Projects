using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateCompleted(ToDoList toDoList)
        {
            if (toDoList.Completed)
            {
                toDoList.Completed = false;
            }
            else
            {
                toDoList.Completed = true;
            };
            context.Entry(toDoList).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
