using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Globalization;

namespace Demo.HR.Models.Db.EFConfigurations
{
    public class UserAllocationConfiguration : IEntityTypeConfiguration<UserAllocation>
    {
        public void Configure(EntityTypeBuilder<UserAllocation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(p => p.UserAllocations).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Project).WithMany().HasForeignKey(p => p.ProjectId);
            builder.HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId);

            builder.HasData(
                new UserAllocation
                {
                    Id = 1,
                    UserId = 1,
                    ProjectId = 1,
                    RoleId = 1,
                    ActualHours = 20,
                    ContractedHours = 32,
                    ContractedHoursApproved = true,
                    StartDate = DateTime.Parse("05/25/2019"),
                    EndDate = DateTime.Parse("05/29/2019"),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
