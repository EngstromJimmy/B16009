using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebAssembly.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyBlogApiController:ControllerBase
    {
        //<Constructor>
        public IMyBlogApi api { get; set; }
        public MyBlogApiController(IMyBlogApi api)
        {
            this.api = api;
        }

        //<GetBlogPostsAsync>
        [HttpGet]
        [Route("BlogPosts")]
        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            return await api.GetBlogPostsAsync(numberofposts, startindex);
        }
        //</GetBlogPostsAsync>

        public Task<int> GetBlogPostCountAsync()
        {
            throw new NotImplementedException();
        }



        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> GetBlogPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public Task<Category> SaveCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> SaveTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }
        //</Constructor>



    }
}
