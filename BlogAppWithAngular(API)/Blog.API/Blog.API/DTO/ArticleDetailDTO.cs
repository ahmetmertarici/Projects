﻿using Blog.Entity;

namespace Blog.API.DTO
{
    public class ArticleDetailDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
        public int ViewsCount { get; set; }
        public double? Score { get; set; }
        public int? ScoreCount { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }
        public int? CommentCount { get; set; }

    }
}