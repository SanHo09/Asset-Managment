using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.Services.ServicesImplement;
using Microsoft.Extensions.DependencyInjection;

namespace SalesWebsite.CustomerSite.Extensions
{
    public static class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
