using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Data.Abstract
{
    public interface ICommentRepository: IRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByArticleAsync(int id);
        void IncreaseCommentLikeCount(int commentId);
        void IncreaseCommentDislikeCount(int commentId);
        Task<int> GetCommentsCountAsync();
        Task<List<Comment>> GetAllCommentsAsync();


    }
}