using Blog.API.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public static class Jobs
    {
        public static string CreateMessage(string title, string message, string alertType)
        {
            var alertMessage = new AlertMessage()
            {
                Title = title,
                Message = message,
                AlertType = alertType
            };
            return JsonConvert.SerializeObject(alertMessage);
        }

        public static string UploadImage(IFormFile file)
        {
            
            var extension = Path.GetExtension(file.FileName);
            var randomName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return randomName;
        }
       
    }
}
