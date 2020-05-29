using System;

namespace Demo.HR.Models.Dtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
