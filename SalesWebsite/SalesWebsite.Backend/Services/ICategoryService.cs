using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services
{
    public interface ICategoryService
    {
        public Task<PagedResponseDto<CategoryDto>> FindAllAsync(CategoryCriteriaDto categoryCriteriaDto);
        public Task<CategoryVm> FindByID(int id);
        public Task<CategoryVm> Create([FromForm] CategoryCreateRequest categoryCreateRequest);
        public Task<CategoryVm> UpdateAsync([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest);
        public Task<CategoryVm> DeleteAsync(int id);
        public IQueryable<Category> CategoryFilter(
            IQueryable<Category> categoriesQuery,
            CategoryCriteriaDto categoryCriteria);
    }
}
