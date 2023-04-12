using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IAboutMeService
    {
        #region Generics
        Task CreateAsync(AboutMe aboutMe);
        Task<AboutMe> GetByIdAsync(int id);
        Task<List<AboutMe>> GetAllAsync();
        void Update(AboutMe aboutMe);
        void Delete(AboutMe aboutMe);
        #endregion

        Task<List<AboutMe>> GetApprovedContent();
        Task<AboutMe> UpdateAboutMeAsync(int aboutMeId, string content, string title);
        void UpdateAboutMeIsApproved(AboutMe aboutMe);


    }
}
