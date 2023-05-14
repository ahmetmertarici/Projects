using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreCommentRepository: EfCoreGenericRepository<Comment>, ICommentRepository
    {
        public EfCoreCommentRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await context
                .Comments
                .OrderByDescending(comment => comment.CommentDate)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByArticleAsync(int id)
        {
            return await context
                .Comments
                .Where(c => c.ArticleId == id)
                .ToListAsync();
        }

        public async Task<int> GetCommentsCountAsync()
        {
            return await context
                .Comments
                .CountAsync();
        }

        public void IncreaseCommentDislikeCount(int commentId)
        {
            var comment = context.Comments
                .FirstOrDefault(c => c.CommentId == commentId);
            if (comment.CommentDislike == null)
            {
                comment.CommentDislike = 1;
            }
            else
            {
                comment.CommentDislike++;

            }
            context.Update(comment);
            context.SaveChanges();
        }

        public void IncreaseCommentLikeCount(int commentId)
        {
            var comment = context.Comments
                .FirstOrDefault(c => c.CommentId == commentId);
            if (comment.CommentLike == null)
            {
                comment.CommentLike = 1;
            }
            else
            {
                comment.CommentLike++;

            }
            context.Update(comment);
            context.SaveChanges();
        }
    }
}