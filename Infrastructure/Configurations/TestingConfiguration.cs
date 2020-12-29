using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configuration
{
    public class TestingConfiguration : IEntityTypeConfiguration<Testing>
    {
        public void Configure(EntityTypeBuilder<Testing> builder)
        {
            builder.ToTable("Guidelines");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.Description).HasColumnType("text");
            builder.Property(x => x.Content).HasColumnType("text");

            builder.HasOne(x => x.Level)
                .WithMany(x => x.testings)
                .HasForeignKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Testings)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.testings)
                .HasForeignKey(x => x.categoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}