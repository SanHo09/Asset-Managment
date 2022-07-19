using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.ViewModels;
using SalesWebsite.Shared.ResponseModels;
namespace SalesWebsite.Backend.Services
{
    public interface ICustomerService
    {
        Task<CustomerVm> RegisterAsync(CustomerCreateRequest customerCreateRequest);
        Task<LoginResponse> LoginAsync(CustomerLoginRequest customerLoginRequest);
        Task<IEnumerable<CustomerVm>> FindAllAsync();
    }
}
