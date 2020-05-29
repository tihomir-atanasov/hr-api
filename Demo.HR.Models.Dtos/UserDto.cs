using System.Collections.Generic;

namespace Demo.HR.Models.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Skills { get; set; }

        public string Notes { get; set; }

        public List<ProjectDto> Projects { get; set; }

        public List<RoleDto> Roles { get; set; }

        public List<UserAllocationDto> Allocations { get; set; }
    }
}