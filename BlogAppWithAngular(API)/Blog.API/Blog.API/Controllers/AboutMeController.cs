using Blog.API.DTO;
using Blog.Business.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController : ControllerBase
    {
        private IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AboutMe>>> GetAboutMeContent()
        {
            var aboutMe = await _aboutMeService.GetApprovedContent();

            return Ok(aboutMe);
        }

        [HttpGet]
        [Route("GetAllAboutMe")]
        public async Task<ActionResult<List<AboutMe>>> GetAllAboutMe()
        {
            var aboutMe = await _aboutMeService.GetAllAsync();

            return Ok(aboutMe);
        }


        [HttpDelete]
        [Route("DeleteAboutMe/{aboutMeId}")]
        public async Task<ActionResult<List<AboutMe>>> DeleteAboutMe(int aboutMeId)
        {
            var aboutMe = await _aboutMeService.GetByIdAsync(aboutMeId);
            _aboutMeService.Delete(aboutMe);

            return Ok(aboutMe);
        }

        [HttpPost]
        [Route("CreateAboutMe")]
        public async Task<ActionResult<List<AboutMe>>> CreateAboutMe([FromForm] AboutMeCreateDTO aboutMeCreateDTO)
        {
            var newAboutMe = new AboutMe
            {
                Content = aboutMeCreateDTO.Content,
                Title=aboutMeCreateDTO.Title,
                IsApproved = false
            };
            await _aboutMeService.CreateAsync(newAboutMe);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateAboutMe/{aboutMeId}")]
        public async Task<IActionResult> UpdateAboutMe([FromRoute] int aboutMeId, [FromForm] AboutMeCreateDTO aboutMeCreateDTO)
        {
            var updatedAboutMe = await _aboutMeService.UpdateAboutMeAsync(aboutMeId, aboutMeCreateDTO.Content, aboutMeCreateDTO.Title);

            return Ok(updatedAboutMe);
        }

        [HttpGet("GetAboutMe/{id}")]
        public async Task<IActionResult> GetAboutMe(int id)
        {
            var aboutMe = await _aboutMeService.GetByIdAsync(id);

            if (aboutMe == null)
            {
                return BadRequest();
            }

            AboutMeCreateDTO aboutMeDTO = new()
            {
                Content = aboutMe.Content,
                Title = aboutMe.Title
            };
            return Ok(aboutMeDTO);
        }

        [HttpPost]
        [Route("UpdateAboutMeIsApproved/{id}")]
        public async Task<IActionResult> UpdateAboutMeIsApproved(int id)
        {
            AboutMe aboutMe = await _aboutMeService.GetByIdAsync(id);
            if (aboutMe == null)
            {
                return BadRequest();
            }
            _aboutMeService.UpdateAboutMeIsApproved(aboutMe);
            return Ok();
        }

    }
}
