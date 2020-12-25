using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//<using>
using MyBlog.Data.Interfaces;
using System.Net.Http;
using MyBlog.Data.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
//</using>
namespace MyBlog.Data
{
    public class MyBlogApiClientSide:IMyBlogApi
    {
        //<Constructor>
        HttpClient httpclient;
        public MyBlogApiClientSide(HttpClient httpclient)
        {
            this.httpclient = httpclient;
        }

        //<Blogpost>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await httpclient.GetFromJsonAsync<BlogPost>($"BlogPosts/{id}");
        }

        public async Task<int> GetBlogPostCountAsync()
        {
            return await httpclient.GetFromJsonAsync<int>("BlogPostsCount");
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            return await httpclient.GetFromJsonAsync<List<BlogPost>>($"BlogPosts?numberofposts={numberofposts}&startindex={startindex}");
        }

        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            try
            {
                var response= await httpclient.DeleteAsync<BlogPost>("BlogPosts",item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            try
            {
                var response = await httpclient.PutAsJsonAsync<BlogPost>("BlogPosts", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
        //</Blogpost>








        public Task DeleteCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }

        

        public Task<List<Category>> GetCategoriesAsync()
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

        public Task<List<Tag>> GetTagsAsync()
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
        //</Constructor>


    }
}
