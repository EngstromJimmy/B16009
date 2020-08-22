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
        DbContextFactory<MyBlogDbContext> factory;
        public MyBlogApiServerSide(DbContextFactory<MyBlogDbContext> factory)
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
        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            using var context = factory.CreateDbContext();
            context.BlogPosts.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            using var context = factory.CreateDbContext();
            context.Categories.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(Tag item)
        {
            using var context = factory.CreateDbContext();
            context.Tags.Remove(item);
            await context.SaveChangesAsync();
        }
        //</Delete>

        //<Save>
        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            using var context = factory.CreateDbContext();
            if(item.Id==0)
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

        public async Task<Category> SaveCategoryAsync(Category item)
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

        public async Task<Tag> SaveTagAsync(Tag item)
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
        //</Save>
    }
}
