using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Shared.Components.ProductInformation
{
    public class ProductInformationViewComponent : ViewComponent
    {
        public ProductVm productVm;
        public ProductInformationViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(ProductVm productVm)
        {
            this.productVm = productVm;
            return View("productInformation", productVm);
        }
    }
}
