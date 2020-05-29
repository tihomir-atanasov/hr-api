using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired();
            builder.HasMany(u => u.UserProjects).WithOne(up => up.User);
            builder.HasMany(u => u.UserRoles).WithOne(ur => ur.User);
            builder.HasMany(u => u.UserAllocations).WithOne(ua => ua.User);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "demo1@test.com",
                    FullName = "Demo User 1",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Email = "demo2@test.com",
                    FullName = "Demo User 2",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    Email = "demo3@test.com",
                    FullName = "Demo User 3",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = 4,
                    Email = "demo4@test.com",
                    FullName = "Demo User 4",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
