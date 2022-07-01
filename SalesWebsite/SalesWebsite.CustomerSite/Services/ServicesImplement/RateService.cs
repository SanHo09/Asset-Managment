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

        public async Task addRate(RateCreateRequest rateCreateRequest)
        {
            
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var response = await client.PostAsJsonAsync(EndpointConstants.getRates, rateCreateRequest);
            var result = await response.Content.ReadAsStringAsync();
            Console.Write(result);
        }

       
    }
}
