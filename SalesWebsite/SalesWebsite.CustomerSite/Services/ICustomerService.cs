using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.Shared.ResponseModels;

namespace SalesWebsite.CustomerSite.Services
{
    public interface ICustomerService
    {
        public Task<LoginResponse> LoginAsync(CustomerLoginRequest customerLoginRequest);
        public Task<bool> RegisterAsync(CustomerCreateRequest customerCreateRequest);
    }
}
