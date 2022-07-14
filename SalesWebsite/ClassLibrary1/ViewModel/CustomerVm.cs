


namespace SalesWebsite.ViewModels
{
    public class CustomerVm
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        virtual public List<RateVm> Rates { get; set; }
    }
}
