using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.DAOs;
using Infrastructure.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Interfaces;
using Web.Services;
using System.Text.Json;
using Web.Middlewares;
using Application.Filters;
using AutoMapper;
using Web.Helper;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute(
                "/product/Index",
                "/dong-ho-nam"

             );
            });
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

            app.UseRewriter(RewriteConfig.options);

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
