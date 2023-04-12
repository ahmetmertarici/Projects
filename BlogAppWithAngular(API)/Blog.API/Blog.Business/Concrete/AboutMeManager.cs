using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class AboutMeManager:IAboutMeService
    {
        private IAboutMeRepository _aboutMeRepository;

        public AboutMeManager(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

        public async Task CreateAsync(AboutMe aboutMe)
        {
            await _aboutMeRepository.CreateAsync(aboutMe);
        }

        public void Delete(AboutMe aboutMe)
        {
            _aboutMeRepository.Delete(aboutMe);
        }

        public async Task<List<AboutMe>> GetAllAsync()
        {
            return await _aboutMeRepository.GetAllAsync();
        }

        public async Task<List<AboutMe>> GetApprovedContent()
        {
            return await _aboutMeRepository.GetApprovedContent();
        }

        public async Task<AboutMe> GetByIdAsync(int id)
        {
            return await _aboutMeRepository.GetByIdAsync(id);
        }

        public void Update(AboutMe aboutMe)
        {
            throw new NotImplementedException();
        }

        public async Task<AboutMe> UpdateAboutMeAsync(int aboutMeId, string content, string title)
        {
            return await _aboutMeRepository.UpdateAboutMeAsync(aboutMeId, content, title);
        }

        public void UpdateAboutMeIsApproved(AboutMe aboutMe)
        {
            _aboutMeRepository.UpdateAboutMeIsApproved(aboutMe);
        }
    }
}
