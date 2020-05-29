using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class UserRole : BaseActiveAndCreatedAt
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
