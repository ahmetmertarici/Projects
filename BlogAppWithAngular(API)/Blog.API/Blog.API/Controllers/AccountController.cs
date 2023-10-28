using Blog.API.DTO;
using Blog.API.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;

        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var myIdentityUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (myIdentityUser == null)
            {
                return BadRequest();
            }

            //if (!await _userManager.IsInRoleAsync(myIdentityUser, "Admin"))
            //{
            //    return Unauthorized();
            //}

            var result = await _signInManager.PasswordSignInAsync(myIdentityUser, loginDTO.Password, loginDTO.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok(new { userRole = "Admin" });
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state.");
            }

            // Create a new user
            MyIdentityUser myIdentityUser = new()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
            };

            // Try to create the user
            var result = await _userManager.CreateAsync(myIdentityUser, registerDTO.Password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Registration successful." });
            }
            else
            {
                return BadRequest(result.Errors.Select(e => e.Description).ToList());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }





    }
}
