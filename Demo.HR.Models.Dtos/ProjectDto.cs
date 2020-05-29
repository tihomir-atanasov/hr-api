using System.Collections.Generic;

namespace Demo.HR.Models.Dtos
{
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public List<UserDto> ActiveUsers { get; set; }
    }
}
