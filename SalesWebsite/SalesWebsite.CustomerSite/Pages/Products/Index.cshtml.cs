using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.CustomerSite.ViewModel.Paged;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(IProductService productService, IConfiguration configuration, IMapper mapper)
        {
            _productService = productService;
            _config = configuration;
            _mapper = mapper;
        }

        public PagedResponseVm<ProductVm> products { get; set; }

        public async Task OnGetAsync(string sortOrder, string rurrentFilter, string searchString, int? pagedIndex)
        {
            var productCateriaDto = new ProductCriteriaDto
            {
                Search = searchString,
                SortColumn = sortOrder,
                Page = pagedIndex ?? 1,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedProductDto = await _productService.GetProductAsync(productCateriaDto);
            products = _mapper.Map<PagedResponseVm<ProductVm>>(pagedProductDto);
            
        }

    }
}
