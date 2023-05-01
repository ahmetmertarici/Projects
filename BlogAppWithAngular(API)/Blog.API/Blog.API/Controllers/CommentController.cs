using Blog.API.DTO;
using Blog.Business.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Comment>>> GetCommentList(int id)
        {
            var comments = await _commentService.GetCommentsByArticleAsync(id);


            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            Comment comment = new()
            {
                Name = createCommentDTO.Name,
                Text = createCommentDTO.Text,
                CommentDate = DateTime.Now.ToString("G"),
                ArticleId = createCommentDTO.ArticleId
            };

            await _commentService.CreateAsync(comment);

            return Ok();
        }


    }
}
