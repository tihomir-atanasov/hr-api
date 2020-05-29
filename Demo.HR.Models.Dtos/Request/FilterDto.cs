namespace Demo.HR.Models.Dtos.Request
{
    public class FilterDto
    {
        public int Page { get; set; } = 1;

        public int Per { get; set; } = 30;

        public string Sort { get; set; } = string.Empty;

        public string SortDir { get; set; } = "asc";

        public int? ProjectId { get; set; }

        public int? UserId { get; set; }
    }
}
