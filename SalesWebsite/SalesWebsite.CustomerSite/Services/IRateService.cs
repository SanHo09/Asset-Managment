using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.CustomerSite.Services
{
    public interface IRateService
    {
        public Task<bool> AddRateAsync(RateCreateRequest rateCreateRequest, string token);
    }
}
