using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services
{
    public interface ICustomerService
    {
        Task<CustomerVm> RegisterAsync(CustomerCreateRequest customerCreateRequest);
        Task<string> LoginAsync(CustomerLoginRequest customerLoginRequest);
        Task<IEnumerable<CustomerVm>> FindAllAsync();
    }
}
