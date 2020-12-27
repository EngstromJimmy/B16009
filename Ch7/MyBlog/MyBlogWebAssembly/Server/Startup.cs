using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
//<using>
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
//</using>
//<IdentityUsing>
using MyBlog.Data.Models;
using Microsoft.AspNetCore.Authentication;
//</IdentityUsing>
namespace MyBlogWebAssembly.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //<Identity>
            services.AddDbContext<MyBlogDbContext>(opt => opt.UseSqlite($"Data Source=../../MyBlog.db"));

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<MyBlogDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, MyBlogDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            //</Identity>

            services.AddControllersWithViews();
            services.AddRazorPages();
            //<AddMyBlogDataServices>
            services.AddDbContextFactory<MyBlogDbContext>(opt => opt.UseSqlite($"Data Source=../../MyBlog.db"));
            services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();
            //</AddMyBlogDataServices>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

          

            app.UseRouting();
            //<IdentityApp>
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            //</IdentityApp>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
