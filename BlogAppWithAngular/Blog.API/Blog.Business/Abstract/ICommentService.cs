using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Business.Abstract
{
    public interface ICommentService
    {
         #region Generics
        Task CreateAsync(Comment comment);
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> GetAllAsync();
        void Update(Comment comment);
        void Delete(Comment comment);
        #endregion

        Task<List<Comment>> GetCommentsByArticleAsync(int id);
        void IncreaseCommentLikeCount(int commentId);
        void IncreaseCommentDislikeCount(int commentId);
    }
}