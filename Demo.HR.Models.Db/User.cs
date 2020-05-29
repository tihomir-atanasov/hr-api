using System;
using System.Collections.Generic;

namespace Demo.HR.Models.Db
{
    public class User : BaseActiveAndCreatedAt
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Skills { get; set; }

        public string Notes { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserAllocation> UserAllocations { get; set; }
    }
}
