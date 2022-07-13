using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services
{
    public interface IProductService
    {
        Task<PagedResponseDto<ProductDto>> FindAllAsync(ProductCriteriaDto productCriteriaDto);
        Task<ProductVm> FindById(int id);
        Task<ProductVm> CreateAsync(ProductCreateRequest productCreateRequest);
        Task<ProductVm> UpdateAsync(int id, ProductCreateRequest productCreateRequest);
        Task<ProductVm> DeleteAsync(int id);
        IQueryable<Product> ProductFilter(
                    IQueryable<Product> productQuery,
                    ProductCriteriaDto productCriteria);
    }
}
