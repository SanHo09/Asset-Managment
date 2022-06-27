namespace SalesWebsite.CustomerSite.ViewModel.Paged
{
    public class PagedResponseVm<TViewModel> : BaseQueryCriteriaVm
    {
        public int CurrentPage { set; get; }
        public int TotalItems { set; get; }
        public int TotalPages { get; set; }
        public IEnumerable<TViewModel> Items { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return Page > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return Page < TotalPages;
            }
        }
    }
}
