using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class Role : BaseActiveAndCreatedAt
    {
        public string Name { get; set; }
    }
}
