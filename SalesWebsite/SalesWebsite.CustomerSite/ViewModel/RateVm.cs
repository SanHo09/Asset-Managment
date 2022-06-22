namespace SalesWebsite.CustomerSite.ViewModel
{
    public class RateVm
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float NumberOfStar { get; set; }

        public ProductVm Product { get; set; }
        public CustomerVm Customer { get; set; }
    }
}
