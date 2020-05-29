using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class Project : BaseActiveAndCreatedAt
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }
    }
}
