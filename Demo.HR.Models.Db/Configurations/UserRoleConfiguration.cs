using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId);

            builder.HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 2,
                    UserId = 1,
                    RoleId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 3,
                    UserId = 2,
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 4,
                    UserId = 1,
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 5,
                    UserId = 3,
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 6,
                    UserId = 3,
                    RoleId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}