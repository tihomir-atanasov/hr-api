using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.HasMany(p => p.UserProjects).WithOne(up => up.Project);

            builder.HasData(
                new Project
                {
                    Id = 1,
                    Name = "Demo Project 1",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 2,
                    Name = "Demo Project 2",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 3,
                    Name = "Demo Project 3",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
