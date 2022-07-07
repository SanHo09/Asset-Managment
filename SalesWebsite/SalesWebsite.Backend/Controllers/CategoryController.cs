﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.ViewModels;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using Microsoft.EntityFrameworkCore;
using SalesWebsite.Backend.Extensions;
using Microsoft.AspNetCore.Cors;
using System.Linq.Dynamic.Core;
namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;

        public CategoryController(SalesWebsiteBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagedResponseDto<CategoryDto>> FindAllAsync([FromQuery] CategoryCriteriaDto categoryCriteriaDto)
        {
            var categoryQuery = _context.Categories
                .Include(i => i.Products)
                .Where(i => !i.IsDeleted)
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


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVm>> FindByID(int id)
        {
            var category = await _context.Categories
                .Include(i => i.Products)
                .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            if (category == null)
            {
                return NotFound();
            }

            var CategoryVm = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,

                Products = _mapper.Map<List<ProductVm>>(category.Products)
            };
            return Ok(CategoryVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            Category category = new Category()
            {
                Name = categoryCreateRequest.Name,
                Description = categoryCreateRequest.Description,
                IsDeleted = false
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getCategory", new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
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
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private IQueryable<Category> CategoryFilter(
            IQueryable<Category> categoriesQuery,
            CategoryCriteriaDto categoryCriteria)
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
