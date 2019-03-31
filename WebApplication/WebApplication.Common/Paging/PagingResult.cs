using System.Collections.Generic;

namespace WebApplication.Common.Paging
{
    public class PagingResult<T>
    {
        public List<T> Items { get; set; }

        public int ItemsTotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PerPage { get; set; }
    }
}
