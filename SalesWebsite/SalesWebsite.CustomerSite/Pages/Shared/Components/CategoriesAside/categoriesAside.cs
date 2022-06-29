using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Shared.Components.CategoriesAside
{
    public class categoriesAsideViewComponent : ViewComponent
    {
        public List<CategoryVm> categories;
        public categoriesAsideViewComponent()
        {

        } 

        public async Task<IViewComponentResult> InvokeAsync(List<CategoryVm> categoriesVm)
        {
            this.categories = categoriesVm;
            return View("categoriesAside", categoriesVm);
        }
    }
}
