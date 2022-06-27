
using Microsoft.Extensions.DependencyInjection;
using SalesWebsite.Shared.Constants;

namespace SalesWebsite.CustomerSite.Extensions.ServiceCollection
{
    public static class HttpClientRegister
    {
        public static void AddCustomHttpClient(this IServiceCollection services, IConfiguration config)
        {
            var configureClient = new Action<IServiceProvider, HttpClient>(async (provider, client) =>
            {
                client.BaseAddress = new Uri(config[ConfigurationConstants.BACK_END_ENDPOINT]);
            });

            services.AddHttpClient(ServiceConstants.BACK_END_NAMED_CLIENT, configureClient);
        }
    }
}
