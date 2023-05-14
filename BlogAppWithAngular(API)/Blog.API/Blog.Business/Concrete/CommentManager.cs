using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entity;

namespace Blog.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task CreateAsync(Comment comment)
        {
            await _commentRepository.CreateAsync(comment);
        }

        public void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetCommentsByArticleAsync(int id)
        {
            return await _commentRepository.GetCommentsByArticleAsync(id);
        }

        public void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
        public void IncreaseCommentDislikeCount(int commentId)
        {
            _commentRepository.IncreaseCommentDislikeCount(commentId);
        }

        public void IncreaseCommentLikeCount(int commentId)
        {
            _commentRepository.IncreaseCommentLikeCount(commentId);
        }

        public async Task<int> GetCommentsCountAsync()
        {
            return await _commentRepository.GetCommentsCountAsync();
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllCommentsAsync();
        }
    }
}