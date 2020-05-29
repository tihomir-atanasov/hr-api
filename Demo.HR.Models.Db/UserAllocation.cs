using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Db
{
    public class UserAllocation : BaseActiveAndCreatedAt
    {
        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int RoleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte ContractedHours { get; set; }

        public byte ActualHours { get; set; }

        public bool ContractedHoursApproved { get; set; }

        public string Notes { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

        public Role Role { get; set; }
    }
}
