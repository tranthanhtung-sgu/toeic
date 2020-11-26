using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;


namespace Infrastructure.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.teacher)
                .WithMany(sc=>sc.Classes)
                .HasForeignKey(x=>x.teacherId);
            builder.HasOne(x=>x.course)
                .WithMany(sc=>sc.Classes)
                .HasForeignKey(x=>x.courseId);
            builder.Property(x=>x.name).IsRequired();
            builder.Property(x=>x.startDate).IsRequired();
            builder.Property(x=>x.endDate).IsRequired();
            builder.Property(x=>x.price).HasDefaultValue(0).HasColumnType("decimal(18,4)");
        }
    }
}