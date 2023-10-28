using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string CommentDate { get; set; }
        public int? CommentLike { get; set; }
        public int? CommentDislike { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public bool Status { get; set; }

    }
}