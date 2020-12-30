 using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.System.Users;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Application;
using Application.System.Roles;
using Infrastructure.Persistence.Repository;
using Application.System.Common;
using System.IO;

namespace API
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
         
            //DI
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ToeicOnlineContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();

            services.AddTransient<ILevelRepositoryAsync, LevelRepositoryAsync>();
            services.AddTransient<IClassRepositoryAsync, ClassRepositoryAsync>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddControllers().AddFluentValidation();
            services.AddSwaggerExtension(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            // WebRootPath == null workaround.
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
