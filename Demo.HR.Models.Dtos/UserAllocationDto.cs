using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.HR.Models.Dtos
{
    public class UserAllocationDto : BaseDto
    {
        public UserDto User { get; set; }

        public ProjectDto Project { get; set; }

        public RoleDto Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ContractedHours { get; set; }

        public int ActualHours { get; set; }

        public string Notes { get; set; }

        public bool ContractedHoursApproved { get; set; }

        public decimal ContractedPercentage
        {
            get
            {
                return ((decimal)ContractedHours / 40) * 100;
            }
        }

        public decimal ActualPercentage
        {
            get
            {
                return ((decimal)ActualHours / 40) * 100;
            }
        }
    }
}
