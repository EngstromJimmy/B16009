using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Models;

namespace MyBlog.Data
{
    public class MyBlogDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
