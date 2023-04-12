using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreAboutMeRepository : EfCoreGenericRepository<AboutMe>, IAboutMeRepository
    {
        public EfCoreAboutMeRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }

        public async Task<List<AboutMe>> GetApprovedContent()
        {
            return await context
                .AboutMe
                .Where(am => am.IsApproved == true)
                .ToListAsync();
        }

        public async Task<AboutMe> UpdateAboutMeAsync(int aboutMeId, string content, string title)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Category bul
                    var aboutMe = await context.AboutMe.FindAsync(aboutMeId);

                    // Category güncelle
                    aboutMe.Title = title;
                    aboutMe.Content = content;

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return aboutMe;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdateAboutMeIsApproved(AboutMe aboutMe)
        {
            if (aboutMe.IsApproved)
            {
                aboutMe.IsApproved = false;
            }
            else
            {
                aboutMe.IsApproved = true;
            }
            context.Entry(aboutMe).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
