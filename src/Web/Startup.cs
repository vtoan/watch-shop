using Infrastructure.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Services;
using Application.Filters;
using AutoMapper;
using Web.Middlewares;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DB use
            services.AddDbContext<WatchContext>(op => op.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WatchContext>();
            //Layer use
            services.AddHelpfulServices();
            services.AddAppServices();
            services.AddDAOService();
            // Framework use
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSession(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
            services.AddRazorPages();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRewriter(RewriteConfig.options);

            // app.UseCookieHandler();

            app.UseRouting();

            // app.UseStatusCodePagesWithRedirects("/error/{0}");

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
