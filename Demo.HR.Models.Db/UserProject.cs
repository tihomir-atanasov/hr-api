using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class UserProject : BaseActiveAndCreatedAt
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }
    }
}
