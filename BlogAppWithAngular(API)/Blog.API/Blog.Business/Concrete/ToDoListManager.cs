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

        public async Task CreateAsync(ToDoList toDoList)
        {
            await _toDoRepository.CreateAsync(toDoList);
        }

        public void Delete(ToDoList toDoList)
        {
            _toDoRepository.Delete(toDoList);
        }

        public async Task<List<ToDoList>> GetAllAsync()
        {
            return await _toDoRepository.GetAllAsync();
        }

        public async Task<ToDoList> GetByIdAsync(int id)
        {
            return await _toDoRepository.GetByIdAsync(id);
        }

        public void Update(ToDoList toDoList)
        {
            _toDoRepository.Update(toDoList);
        }

        public async Task UpdateCompleted(ToDoList toDoList)
        {
            await _toDoRepository.UpdateCompleted(toDoList);

        }
    }
}
