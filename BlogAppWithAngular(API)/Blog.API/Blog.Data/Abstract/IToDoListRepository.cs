using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Abstract
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        Task UpdateCompleted(ToDoList toDoList);
    }
}
