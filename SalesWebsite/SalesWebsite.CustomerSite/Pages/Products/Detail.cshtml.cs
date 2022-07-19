using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Constants;
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
            try
            {
                if (product.Rates != null)
                {
                    product.Rate = product.Rates.Average(rate => rate.NumberOfStar);
                }
            } catch(Exception ex)
            {
                product.Rate = 5;
            }
        }

        public async Task OnPostRate(int productId)
        {
            
            // get token from cookie and pass to Service to Authorized
            string userName = Request.Cookies["userName"];
            string token = Request.Cookies["token"];
            
            if(token == null)
            {
                Response.Redirect(PagesConstants.LOGIN);
            }

            string content = Request.Form["content"];
            string star = Request.Form["star"];

            int startNumber = int.Parse(star);

            RateCreateRequest rateCreateRequest = new RateCreateRequest()
            {
                UserName = userName,
                ProductId = productId,
                Content = content,
                NumberOfStar = startNumber
            };

            await _rateService.AddRateAsync(rateCreateRequest, token);
            product = await _productService.GetProductByIdAsync(productId);
            try
            {
                product.Rate = product.Rates.Average(rate => rate.NumberOfStar);
            } catch
            {
                // Catch if Product has none rates 
            }

        }
    }
}
