using Blog.API.DTO;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net;
using MailKit.Net.Smtp;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendContactEmail(ContactDTO contactDTO)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("User", contactDTO.Email));
            message.To.Add(new MailboxAddress("Admin", "ahmetarici4@gmail.com"));
            message.Subject = contactDTO.Subject;
            message.Body = new TextPart("plain")
            {
                Text = contactDTO.Message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("gereksizuygulamalaricinmail@gmail.com", "elpaopvrtxbyzkyq");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok();
        }
    }
}
    

