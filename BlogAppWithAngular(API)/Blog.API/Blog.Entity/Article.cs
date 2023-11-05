using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
        public int ViewsCount { get; set; }
        public double? Score { get; set; } 
        public int? ScoreCount { get; set; } 
        public bool IsApproved { get; set; }
        public string? ImageUrl { get; set; }
        public List<ArticleCategory> ArticleCategories { get; set; }
        public List<Comment> Comments { get; set; }
        public bool Status { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}