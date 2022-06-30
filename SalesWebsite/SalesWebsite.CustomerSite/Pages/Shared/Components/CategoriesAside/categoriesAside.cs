using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.CustomerSite.ViewModel.Paged;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto.Category;

namespace SalesWebsite.CustomerSite.Pages.Shared.Components.CategoriesAside
{
    public class categoriesAsideViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public PagedResponseVm<CategoryVm> categories;
        public categoriesAsideViewComponent(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryDto = new CategoryCriteriaDto
            {
                Search = "",
                SortColumn = "",
                Page = 1,
                Limit = 10 //int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedCategoriesDto = await _categoryService.GetCategoriesAsync(categoryDto);
            this.categories = _mapper.Map<PagedResponseVm<CategoryVm>>(pagedCategoriesDto);
            return View("categoriesAside", categories);
        }
    }
}
