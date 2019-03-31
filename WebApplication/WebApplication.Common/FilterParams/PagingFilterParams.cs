namespace WebApplication.Common.FilterParams
{
    public class PagingFilterParams
    {
        public PagingFilterParams()
        {
            PerPage = DataConsts.ItemsPerPage;
        }

        // other params

        public int PageNumber { get; set; }

        public int PerPage { get; set; }
    }
}
