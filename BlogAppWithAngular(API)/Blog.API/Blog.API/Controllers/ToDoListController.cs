using Blog.API.DTO;
using Blog.Business.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private IToDoListService _toDoService;

        public ToDoListController(IToDoListService toDoService)
        {
            _toDoService = toDoService;
        }
        [HttpGet]
        [Route("GetAllToDo")]
        public async Task<ActionResult<List<ToDoList>>> GetAllToDo()
        {
            var toDo = await _toDoService.GetAllAsync();

            return Ok(toDo);
        }
        
        [HttpPost]
        [Route("UpdateCompleted/{id}")]
        public async Task<IActionResult> UpdateCompleted(int id)
        {
            ToDoList toDo = await _toDoService.GetByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            _toDoService.UpdateCompleted(toDo);
            return Ok();
        }
        [HttpPost]
        [Route("CreateToDo")]
        public async Task<ActionResult<List<CreateToDoDTO>>> CreateToDo([FromForm] CreateToDoDTO toDoList)
        {
            var newToDo = new ToDoList
            {
                Title= toDoList.Title,
                Text= toDoList.Text,
                Comment= toDoList.Comment,
                Completed=false,
                Status=true

            };
            await _toDoService.CreateAsync(newToDo);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateTodo/{id}")]
        public IActionResult UpdateTodo([FromRoute] int id, [FromForm] ToDoList todoList)
        {
            var todo = new ToDoList
            {
                ID = id,
                Title = todoList.Title,
                Text = todoList.Text,
                Comment = todoList.Comment
            };
            _toDoService.Update(todo);

            return Ok();
        }
        [HttpGet("GetTodo/{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var aboutMe = await _toDoService.GetByIdAsync(id);

            if (aboutMe == null)
            {
                return BadRequest();
            }

            CreateToDoDTO createToDoDTO = new()
            {
                Title = aboutMe.Title,
                Text=aboutMe.Text,
                Comment=aboutMe.Comment
            };
            return Ok(createToDoDTO);
        }
        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public async Task<ActionResult<List<ToDoList>>> DeleteTodo(int id)
        {
            var todo = await _toDoService.GetByIdAsync(id);

            _toDoService.Delete(todo);

            return Ok();
        }
    }
}
