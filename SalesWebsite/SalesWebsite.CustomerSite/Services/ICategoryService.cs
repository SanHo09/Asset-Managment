using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;

namespace SalesWebsite.CustomerSite.Services
{
    public interface ICategoryService
    {
        Task<PagedResponseDto<CategoryDto>> GetCategoriesAsync(CategoryCriteriaDto categoryCriteriaDto);
        Task<CategoryDto> GetCategoryByIdAsync(int id);

    }
}
