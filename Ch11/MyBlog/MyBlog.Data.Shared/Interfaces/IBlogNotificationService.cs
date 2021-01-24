using MyBlog.Data.Models;
using System;
using System.Threading.Tasks;

namespace MyBlog.Data.Shared.Interfaces
{
    public interface IBlogNotificationService
    {
        Action<BlogPost> BlogPostChanged { get; set; }
        Task SendNotification(BlogPost post);
    }
}
