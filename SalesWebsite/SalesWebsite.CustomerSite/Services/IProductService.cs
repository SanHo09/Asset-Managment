using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Services
{
    public interface IProductService
    {
        Task<PagedResponseDto<ProductDto>> GetProductAsync(ProductCriteriaDto productCriteriaDto);
        Task<ProductVm> GetProductByIdAsync(int productId);
    }
}
