using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Abstract
{
    public interface IAboutMeRepository : IRepository<AboutMe>
    {
        Task<List<AboutMe>> GetApprovedContent();
        Task<AboutMe> UpdateAboutMeAsync(int aboutMeId, string content, string title);
        void UpdateAboutMeIsApproved(AboutMe aboutMe);


    }
}
