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

        public async Task OnGetAsync(string sortOrder, string crurrentFilter, string searchString, int? pagedIndex)
        {
            var pageIndexFormat = pagedIndex ?? 1;
            var totalPages = int.Parse(Request.Cookies["ProductTotalPage"] ?? "1");

            if (pageIndexFormat < 1)
            {
                pagedIndex = 1;
            }
            else if (pageIndexFormat > totalPages)
            {
                pagedIndex = totalPages;
            }
            var productCateriaDto = new ProductCriteriaDto
            {
                Search = searchString,
                SortColumn = sortOrder,
                Page = pagedIndex ?? 1,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedProductDto = await _productService.GetProductAsync(productCateriaDto);
            var cookieOption = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1),
            };
            Response.Cookies.Append("ProductTotalPage", pagedProductDto.TotalPages + "", cookieOption);
            Response.Cookies.Append("CurrentPage", pagedProductDto.CurrentPage + "", cookieOption);
            products = _mapper.Map<PagedResponseVm<ProductVm>>(pagedProductDto);
        }


    }
}
