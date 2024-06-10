﻿namespace CodeBlog.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDiscription { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FeatureImageUrl { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
    }
}
