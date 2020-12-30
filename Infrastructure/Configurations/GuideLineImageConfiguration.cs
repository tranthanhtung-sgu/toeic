using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GuideLineImageConfiguration : IEntityTypeConfiguration<GuideLineImage>
    {
        public void Configure(EntityTypeBuilder<GuideLineImage> builder)
        {
            builder.ToTable("GuideLineImages");
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);

            builder.HasOne(x => x.GuideLine)
                .WithMany(x => x.images)
                .HasForeignKey(x => x.GuideLineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
