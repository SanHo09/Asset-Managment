using Microsoft.AspNetCore.Mvc;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Shared.Components.ProductRates.Rates
{
    public class ProductRatesViewComponent : ViewComponent
    {
        IRateService _rateService;
        public ProductVm ProductVm;

        public ProductRatesViewComponent(IRateService rateService)
        {
            _rateService = rateService;

        }

        public async Task<IViewComponentResult> InvokeAsync(ProductVm productVm)
        {
            this.ProductVm = productVm;
            return View("ProductRates", productVm);
        }
    }
}
