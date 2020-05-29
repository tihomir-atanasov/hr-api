using System;
using Demo.HR.Models.Common.Enums;

namespace Demo.HR.Models.Dtos.Request
{
    public class AllocationsFilterDto : FilterDto
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? RoleId { get; set; }

        public BusinessFilters? FilterRule { get; set; }
    }
}
