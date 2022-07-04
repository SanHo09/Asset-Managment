using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.CustomerSite.ViewModel.Paged;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Pages.Categories
{

    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public IndexModel(ICategoryService categoryService, IConfiguration config, IMapper mapper, IProductService productService)
        {
            _categoryService = categoryService;
            _config = config;
            _mapper = mapper;
            _productService = productService;
        }

        public PagedResponseVm<CategoryVm> categories { get; set; }
        public PagedResponseVm<ProductVm> products { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            var categoryCriteriaDto = new CategoryCriteriaDto()
            {
                Search = searchString,
                SortColumn = sortOrder,
                Page = pageIndex ?? 1,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedCategoriesDto= await _categoryService.GetCategoriesAsync(categoryCriteriaDto);
            categories = _mapper.Map<PagedResponseVm<CategoryVm>>(pagedCategoriesDto);
            await GetCategories(sortOrder, currentFilter, searchString, pageIndex);          
        }

        public async Task GetCategories(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            var categoryDto = new CategoryCriteriaDto
            {
                Search = searchString,
                SortColumn = sortOrder,
                Page = pageIndex ?? 1,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedCategoriesDto = await _categoryService.GetCategoriesAsync(categoryDto);
            this.categories = _mapper.Map<PagedResponseVm<CategoryVm>>(pagedCategoriesDto);
        }
    }

}
