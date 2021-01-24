using MyBlog.Data.Models;
using MyBlog.Data.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyBlogServerSide.Services
{
    public class BlazorServerBlogNotificationService : IBlogNotificationService
    {
        public Action<BlogPost> BlogPostChanged { get; set; }

        public Task SendNotification(BlogPost post)
        {
            BlogPostChanged?.Invoke(post);
            return Task.CompletedTask;
        }
    }
}
