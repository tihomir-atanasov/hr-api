using System.Collections.Generic;

namespace Demo.HR.Models.Dtos.Response
{
    public class PagedResultDto<T>
    {
        public int Total { get; set; }

        public int Page { get; set; }

        public int Per { get; set; }

        public ICollection<T> Data { get; set; }
    }
}
