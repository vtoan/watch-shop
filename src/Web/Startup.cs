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
            services.AddRazorPages();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRewriter(RewriteConfig.options);

            app.UseStatusCodePages();

            app.UseHttpsRedirection();


            app.UseRouting();

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
