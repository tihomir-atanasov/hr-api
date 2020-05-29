using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class BaseActiveAndCreatedAt : Base
    {
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
