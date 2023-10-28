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
        public async Task<ActionResult<List<ToDoList>>> GetAllAboutMe()
        {
            var toDo = await _toDoService.GetAllAsync();

            return Ok(toDo);
        }
    }
}
