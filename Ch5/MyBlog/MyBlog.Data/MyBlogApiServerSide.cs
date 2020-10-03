using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlog.Data
{
    public class MyBlogApiServerSide : IMyBlogApi
    {
        //<Constructor>
        IDbContextFactory<MyBlogDbContext> factory;
        public MyBlogApiServerSide(IDbContextFactory<MyBlogDbContext> factory)
        {
            this.factory = factory;
        }
        //</Constructor>

        //<Get>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.BlogPosts.Include(p=>p.Category).Include(p=>p.Tags).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int pagesize,int page)
        {
            using var context = factory.CreateDbContext();
            return await context.BlogPosts.Skip(pagesize*page).Take(pagesize).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Categories.Include(p => p.BlogPosts).FirstOrDefaultAsync(c=>c.Id==id);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            using var context = factory.CreateDbContext();
            return await context.Tags.Include(p => p.BlogPosts).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            using var context = factory.CreateDbContext();
            return await context.Tags.ToListAsync();
        }
        //</Get>

        //<Delete>
        private async Task deleteItem(IMyBlogItem item)
        {
            using var context = factory.CreateDbContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }
        //</Delete>
        
        //<DeleteMethods>
        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            await deleteItem(item);
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            await deleteItem(item);
        }

        public async Task DeleteTagAsync(Tag item)
        {
            await deleteItem(item);
        }
        //</DeleteMethods>

        //<Save>
        private async Task<IMyBlogItem> saveItem(IMyBlogItem item)
        {
            using var context = factory.CreateDbContext();
            if (item.Id == 0)
            {
                context.Add(item);
            }
            else
            {
                context.Attach(item);
            }
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            return (await saveItem(item)) as BlogPost;
        }

        public async Task<Category> SaveCategoryAsync(Category item)
        {
            return (await saveItem(item)) as Category;
        }

        public async Task<Tag> SaveTagAsync(Tag item)
        {
            return (await saveItem(item)) as Tag;
        }
        //</Save> 
    }
}
