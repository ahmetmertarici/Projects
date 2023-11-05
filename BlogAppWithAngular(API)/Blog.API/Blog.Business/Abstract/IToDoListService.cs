using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IToDoListService
    {
        #region Generics
        Task CreateAsync(ToDoList toDoList);
        Task<ToDoList> GetByIdAsync(int id);
        Task<List<ToDoList>> GetAllAsync();
        void Update(ToDoList toDoList);
        void Delete(ToDoList toDoList);
        #endregion
        Task UpdateCompleted(ToDoList toDoList);

    }
}
