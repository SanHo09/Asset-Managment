using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.CustomerSite.Pages.Products
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IRateService _rateService;
        private readonly IConfiguration _config;
        
        
        public DetailModel(IProductService productService, IConfiguration config, IRateService rateService)
        {
            _productService = productService;
            _config = config;
            _rateService = rateService;
        }

        public ProductVm product { get; set; }

        public async Task OnGet(int id)
        {
            product = await _productService.GetProductByIdAsync(id);
            if(product.Rate != null) { 
                product.Rate = product.Rates.Average(rate => rate.NumberOfStar);
            }
        }

        public async Task OnPost(int productId)
        {
            
            int customerId = 1;
            string content = Request.Form["content"];
            string a = Request.Form["star"];
            int startNumber = int.Parse(Request.Form["star"]);
            RateCreateRequest rateCreateRequest = new RateCreateRequest()
            {
                CustomerId = customerId,
                ProductId = productId,
                Content = content,
                NumberOfStar = startNumber
            };
            await _rateService.addRate(rateCreateRequest);
            product = await _productService.GetProductByIdAsync(productId);
            product.Rate = product.Rates.Average(rate => rate.NumberOfStar);
            // cập nhật rate của product lại theo rates

        }
    }
}
