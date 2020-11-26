using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            
            builder.HasOne(x=>x.category)
                .WithMany(x=>x.courses)
                .HasForeignKey(x=>x.categoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(x=>x.level)
                .WithMany(x=>x.courses)
                .HasForeignKey(x=>x.levelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}