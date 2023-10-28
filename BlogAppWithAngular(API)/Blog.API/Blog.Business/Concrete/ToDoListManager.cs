using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        private IToDoListRepository _toDoRepository;

        public ToDoListManager(IToDoListRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public Task CreateAsync(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        public void Delete(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDoList>> GetAllAsync()
        {
            return await _toDoRepository.GetAllAsync();
        }

        public Task<ToDoList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }
    }
}
