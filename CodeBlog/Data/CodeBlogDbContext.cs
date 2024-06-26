﻿using CodeBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeBlog.Data
{
    public class CodeBlogDbContext : DbContext
    {
        public CodeBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
