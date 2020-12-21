using Application;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace mvcMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToeicOnlineContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcToeicContext")));
            services.AddApplicationLayer();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews().AddFluentValidation();
            // services.AddDbContext<ToeicOnlineContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("MvcToeicContext"),
            //     b => b.MigrationsAssembly("Infrastructure")));
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ToeicOnlineContext>().AddDefaultTokenProviders();
            services.AddApiVersioning();
            services.AddTransient<ILevelRepositoryAsync, LevelRepositoryAsync>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
