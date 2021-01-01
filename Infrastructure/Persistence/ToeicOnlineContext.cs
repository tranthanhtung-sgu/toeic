using Microsoft.EntityFrameworkCore;
using Infrastructure.Configuration;
using Domain.Models;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;

namespace Infrastructure.Persistence
{
    public class ToeicOnlineContext : IdentityDbContext<User, Role, int> 
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new StudentInClassConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());

            
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(x=> new {x.UserId, x.RoleId});
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(x=>x.UserId);
            

            // modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public ToeicOnlineContext (DbContextOptions<ToeicOnlineContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Class { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<GuideLine> GuideLine { get; set; }
        public DbSet<Testing> Testing { get; set; }
        public DbSet<GuideLineImage> GuideLineImage { get; set; }
    }
}