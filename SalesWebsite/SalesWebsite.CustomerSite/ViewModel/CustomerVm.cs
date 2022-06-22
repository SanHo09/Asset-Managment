namespace SalesWebsite.CustomerSite.ViewModel
{
    public class CustomerVm
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Isdeleted { get; set; } = true;

        virtual public List<RateVm> rates { get; set; }
    }
}
