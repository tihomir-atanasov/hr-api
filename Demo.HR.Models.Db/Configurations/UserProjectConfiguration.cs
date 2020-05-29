using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(up => up.UserProjects).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Project).WithMany(up => up.UserProjects).HasForeignKey(p => p.ProjectId);

            builder.HasData(
                new UserProject
                {
                    Id = 1,
                    UserId = 1,
                    ProjectId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserProject
                {
                    Id = 2,
                    UserId = 1,
                    ProjectId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserProject
                {
                    Id = 3,
                    UserId = 2,
                    ProjectId = 2,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserProject
                {
                    Id = 4,
                    UserId = 1,
                    ProjectId = 3,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new UserProject
                {
                    Id = 5,
                    UserId = 3,
                    ProjectId = 3,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
