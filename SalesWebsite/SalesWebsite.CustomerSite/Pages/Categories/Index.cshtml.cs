using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.ViewModel;

namespace SalesWebsite.CustomerSite.Pages.Categories
{

    public class IndexModel : PageModel
    {
        
        public CategoryVm category = new CategoryVm() { Id = 1, Description = "Dụng cụ âm nhạc", Name = "Âm nhạc" };
        
    }
}
