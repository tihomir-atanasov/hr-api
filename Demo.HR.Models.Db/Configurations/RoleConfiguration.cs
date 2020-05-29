using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();

            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Demo Role 1",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 2,
                    Name = "Demo Role 2",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
