using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Products
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        
        public DetailModel(IProductService productService, IConfiguration config)
        {
            _productService = productService;
            _config = config;
            
        }

        public ProductVm product { get; set; }

        public async Task OnGet(int id)
        {
            product = await _productService.GetProductByIdAsync(id);
            
        }
    }
}
