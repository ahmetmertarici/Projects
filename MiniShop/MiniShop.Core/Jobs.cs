using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Core
{
    public static class Jobs
    {
        public static string UploadImage(IFormFile file, string url)
        {
            //url=iphone-13-pro
            //file.FileName=iphone 13.png
            //randomName=iphone-13-pro-dsfaasdfadsfsadfasd0329438wasdfdsfads.png
            //path=MiniShop.WebUI/wwwroot/images/iphone-13-pro-dsfaasdfadsfsadfasd0329438wasdfdsfads.png
            var extension = Path.GetExtension(file.FileName);
            var randomName = $"{url}-{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return randomName;
        }

        public static string MakeUrl(string url)
        {
            //Iphone 13 Pro Max İşçi Şehri
            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");

            url = url.ToLower();

            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ğ", "g");
            url = url.Replace("ç", "c");
            url = url.Replace("ş", "s");

            url = url.Replace("/", "");
            url = url.Replace("\\", "");
            url = url.Replace(".", "");
            url = url.Replace(" ", "-");

            return url;
            //iphone-13-pro-max-isci-sehri
        }

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
    }
}
