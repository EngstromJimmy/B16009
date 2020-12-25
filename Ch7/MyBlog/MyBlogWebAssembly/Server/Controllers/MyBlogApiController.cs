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
        //</Constructor>
        //<GetBlogPostsAsync>
        [HttpGet]
        [Route("BlogPosts")]
        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            return await api.GetBlogPostsAsync(numberofposts, startindex);
        }
        //</GetBlogPostsAsync>

        //<GetBlogPostCountAsync>
        public async Task<int> GetBlogPostCountAsync()
        {
            return await api.GetBlogPostCountAsync();
        }
        //</GetBlogPostCountAsync>

        //<GetBlogPostAsync>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await api.GetBlogPostAsync(id);
        }
        //</GetBlogPostAsync>

        //<GetCategoriesAsync>
        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
        //</GetCategoriesAsync>

        //<GetTagsAsync>
        public Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }
        //</GetTagsAsync>

        //<GetCategoryAsync>
        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
        //</GetCategoryAsync>

        //<GetTagAsync>
        public Task<Tag> GetTagAsync(int id)
        {
            throw new NotImplementedException();
        }
        //</GetTagAsync>

        //<SaveBlogPostAsync>
        public Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }
        //</SaveBlogPostAsync>

        //<SaveCategoryAsync>
        public Task<Category> SaveCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }
        //</SaveCategoryAsync>

        //<SaveTagAsync>
        public Task<Tag> SaveTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }
        //</SaveTagAsync>

        //<DeleteBlogPostAsync>
        public Task DeleteBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }
        //</DeleteBlogPostAsync>

        //<DeleteCategoryAsync>
        public Task DeleteCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }
        //</DeleteCategoryAsync>
        //<DeleteTagAsync>
        public Task DeleteTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }
        //</DeleteTagAsync>



    }
}
