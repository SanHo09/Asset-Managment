using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.CustomerSite.Services
{
    public interface IRateService
    {
        public Task addRate(RateCreateRequest rateCreateRequest);
    }
}
