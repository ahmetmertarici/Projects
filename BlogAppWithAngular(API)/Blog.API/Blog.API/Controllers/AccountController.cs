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
            //var myIdentityUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            //if (myIdentityUser == null)
            //{
            //    return BadRequest();
            //}

            //if (!await _userManager.IsInRoleAsync(myIdentityUser, "Admin"))
            //{
            //    return Unauthorized();
            //}

            //var result = await _signInManager.PasswordSignInAsync(myIdentityUser, loginDTO.Password, loginDTO.RememberMe, false);
            //if (result.Succeeded)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, myIdentityUser.UserName),
            //        new Claim(ClaimTypes.Role, "Admin")
            //    };
            //    var token = GenerateJwtToken(claims); // JWT token oluşturma işlemi

            //    return Ok(new { token, userRole = "Admin" });
            //}
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }





    }
}
