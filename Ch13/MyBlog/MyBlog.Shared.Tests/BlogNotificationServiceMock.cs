using MyBlog.Data.Models;
using MyBlog.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyBlog.Shared.Tests
{
    public class BlogNotificationServiceMock : IBlogNotificationService
    {
        public event Action<BlogPost> BlogPostChanged;

        public Task SendNotification(BlogPost post)
        {
            return Task.CompletedTask;
        }
    }
}
