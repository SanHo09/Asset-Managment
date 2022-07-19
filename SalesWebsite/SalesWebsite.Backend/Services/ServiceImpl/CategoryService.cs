using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Extensions;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;

        public CategoryService(SalesWebsiteBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponseDto<CategoryDto>> FindAllAsync(CategoryCriteriaDto categoryCriteriaDto)
        {
            var categoryQuery = _context.Categories
                .Include(category => category.Products.Where(product => !product.IsDeleted))
                .Where(category => !category.IsDeleted)
                .AsQueryable();
            // Lọc category theo tên
            categoryQuery = CategoryFilter(categoryQuery, categoryCriteriaDto);
            // Chuyển dữ liệu từ truy vấn tổng hợp lại thành các thông tin: số trang, tổng số trang, sản phẩm
            var pagedCategories = await categoryQuery.AsNoTracking().paginateAsync(categoryCriteriaDto);

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(pagedCategories.Items);
            return new PagedResponseDto<CategoryDto>
            {
                CurrentPage = pagedCategories.CurrentPage,
                TotalPages = pagedCategories.TotalPages,
                TotalItems = pagedCategories.TotalItems,
                Search = categoryCriteriaDto.Search,
                SortColumn = categoryCriteriaDto.SortColumn,
                SortOrder = categoryCriteriaDto.SortOrder,
                Limit = categoryCriteriaDto.Limit,
                Items = categoryDto
            };
        }

        public async Task<CategoryVm> FindByID(int id)
        {
            var category = await _context.Categories
                .Include(category => category.Products.Where(product => !product.IsDeleted))
                .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            if (category == null)
            {
                return null;
            }

            var CategoryVm = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,

                Products = _mapper.Map<List<ProductVm>>(category.Products)
            };
            return CategoryVm;
        }

        public async Task<CategoryVm> Create(CategoryCreateRequest categoryCreateRequest)
        {

            Category category = new Category()
            {
                Name = categoryCreateRequest.Name,
                Description = categoryCreateRequest.Description,
                IsDeleted = false
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVm> UpdateAsync(int id, CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(category.Name))
            {
                category.Name = categoryCreateRequest.Name;
            }
            if (!string.IsNullOrEmpty(category.Description))
            {
                category.Description = categoryCreateRequest.Description;
            }

            await _context.SaveChangesAsync();
            return new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVm> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.IsDeleted = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
       
        public IQueryable<Category> CategoryFilter(IQueryable<Category> categoriesQuery, CategoryCriteriaDto categoryCriteria)
        {
            if (!String.IsNullOrEmpty(categoryCriteria.Search) && !categoryCriteria.Search.Contains("all"))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(categoryCriteria.Search) ||
                                                c.Id.ToString().Contains(categoryCriteria.Search));
            }
            return categoriesQuery;
        }
    }
}
