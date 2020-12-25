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
using MyBlog.Data.Extensions;
using Newtonsoft.Json;
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
        //</Constructor>

        //<BlogpostGet>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await httpclient.GetFromJsonAsync<BlogPost>($"MyBlogAPI/BlogPosts/{id}");
        }

        public async Task<int> GetBlogPostCountAsync()
        {
            return await httpclient.GetFromJsonAsync<int>("MyBlogAPI/BlogPostsCount");
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            return await httpclient.GetFromJsonAsync<List<BlogPost>>($"MyBlogAPI/BlogPosts?numberofposts={numberofposts}&startindex={startindex}");
        }
        //</BlogpostGet>
        //<BlogpostSaveDelete>
        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            try
            {
                var response= await httpclient.PutAsJsonAsync<BlogPost>("MyBlogAPI/BlogPosts",item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BlogPost>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }

        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            try
            {
                await httpclient.DeleteAsJsonAsync<BlogPost>("MyBlogAPI/BlogPosts", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
        //<BlogpostSaveDelete>

        //<Categories>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await httpclient.GetFromJsonAsync<List<Category>>($"MyBlogAPI/Category");
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await httpclient.GetFromJsonAsync<Category>($"MyBlogAPI/Category/{id}");
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            try
            {
                await httpclient.DeleteAsJsonAsync<Category>("MyBlogAPI/Categories", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
        public async Task<Category> SaveCategoryAsync(Category item)
        {
            try
            {
                var response = await httpclient.PutAsJsonAsync<Category>("MyBlogAPI/Categories", item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Category>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }
        //</Categories>

        //<Tags>
        public async Task<Tag> GetTagAsync(int id)
        {
            return await httpclient.GetFromJsonAsync<Tag>($"MyBlogAPI/Tags/{id}");
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await httpclient.GetFromJsonAsync<List<Tag>>($"MyBlogAPI/Tags");
        }

        public async Task DeleteTagAsync(Tag item)
        {
            try
            {
                await httpclient.DeleteAsJsonAsync<Tag>("MyBlogAPI/Categories", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task<Tag> SaveTagAsync(Tag item)
        {
            try
            {
                var response = await httpclient.PutAsJsonAsync<Tag>("MyBlogAPI/Tags", item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tag>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }
        //</Tags>
    }
}
