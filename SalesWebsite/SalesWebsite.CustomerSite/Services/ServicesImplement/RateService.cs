using Newtonsoft.Json;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.CustomerSite.Services.ServicesImplement
{
    public class RateService : IRateService
    {
        private readonly IHttpClientFactory _clientFactory;
        public RateService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> AddRateAsync(RateCreateRequest rateCreateRequest, string token)
        {
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PostAsJsonAsync(EndpointConstants.getRates, rateCreateRequest);
            Console.Write(response.Content.ToString());
            return response.IsSuccessStatusCode;
        }

       
    }
}
