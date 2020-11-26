using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.amount).HasColumnType("decimal(18,4)");
            builder.HasOne(x=>x.Student)
                .WithMany(x => x.payments)
                .HasForeignKey(x => x.studentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Class)
                .WithMany(x => x.payments)
                .HasForeignKey(x => x.classId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}