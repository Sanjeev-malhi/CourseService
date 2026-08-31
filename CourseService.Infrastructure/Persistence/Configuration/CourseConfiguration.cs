using CourseService.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Infrastructure.Persistence.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();

            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.IsPublished);

            builder.HasMany(x => x.Modules)
                   .WithOne(x => x.Course)
                   .HasForeignKey(x => x.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
