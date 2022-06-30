using Microsoft.AspNetCore.Mvc;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Shared.Components.ProductRates.Rates
{
    public class ProductRatesViewComponent : ViewComponent
    {
        public List<RateVm> rates;
        
        public ProductRatesViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(List<RateVm> rateVm)
        {
            this.rates = rateVm;
            return View("ProductRates", rateVm);
        }
    }
}
