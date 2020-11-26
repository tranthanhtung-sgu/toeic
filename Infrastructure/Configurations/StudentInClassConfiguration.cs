using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configuration
{
    public class StudentInClassConfiguration : IEntityTypeConfiguration<StudentInClass>
    {
        public void Configure(EntityTypeBuilder<StudentInClass> builder)
        {
            builder.ToTable("StudentInClasses");
            
            builder.HasKey(t=> new {t.studentId, t.classId});
            
            builder.HasOne(t=>t.student)
                .WithMany(sc=>sc.studentInClasses)
                .HasForeignKey(sc=>sc.studentId);

            builder.HasOne(t=>t.classs)
                .WithMany(sc=>sc.studentInClasses)
                .HasForeignKey(sc=>sc.classId);
        }
    }
}