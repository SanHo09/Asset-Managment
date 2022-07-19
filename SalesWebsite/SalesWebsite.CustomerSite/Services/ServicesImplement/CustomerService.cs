using Microsoft.AspNetCore.Mvc;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.Shared.ResponseModels;

namespace SalesWebsite.CustomerSite.Services.ServicesImplement
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
           
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LoginResponse> LoginAsync(CustomerLoginRequest customerLoginRequest)
        {
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsJsonAsync(EndpointConstants.login, customerLoginRequest);
            if(response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadAsAsync<LoginResponse>();
                // Set token and model to Cookie
                return loginResponse;
            }
            return null;
            
        }

        public async Task<bool> RegisterAsync(CustomerCreateRequest customerCreateRequest)
        {
            var client = _httpClientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsJsonAsync(EndpointConstants.register, customerCreateRequest);
           
            return response.IsSuccessStatusCode;
        }
    }
}
