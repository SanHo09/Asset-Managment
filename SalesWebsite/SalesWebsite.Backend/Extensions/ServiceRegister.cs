using SalesWebsite.Backend.Services;
using SalesWebsite.Backend.Services.ServiceImpl;

namespace SalesWebsite.Backend.Extensions
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
