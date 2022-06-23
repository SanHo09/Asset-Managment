using AutoMapper;
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

        public async Task<PagedResponseDto<Category>> findAllAsync([FromQuery]CategoryCriteriaDto categoryCriteriaDto)
        {
           
            var categoryQuery = _context.Categories
                .Where(i => !i.IsDeleted)
                .AsQueryable();
            // Lọc category theo tên
            categoryQuery = CategoryFilter(categoryQuery, categoryCriteriaDto);
            // Tạo Extension để paging
            var pagedCategories = await categoryQuery.AsNoTracking().paginateAsync(categoryCriteriaDto);

            var categoryDto = _mapper.Map<IEnumerable<Category>>(pagedCategories.Items);
            return new PagedResponseDto<Category>
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
        public ActionResult<CategoryVm> findByID(int id)
        {
            var category = _context.Categories.FirstOrDefault(i => i.Id == id && i.IsDeleted == false);
            if(category == null)
            {
                return NotFound();
            }

            var CategoryVm = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,   
                Description = category.Description,
            };
            return Ok(CategoryVm);

        }


        [HttpPost]
        public IActionResult create([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            Category _category = new Category()
            {
                Name = categoryCreateRequest.Name,
                Description = categoryCreateRequest.Description,
                IsDeleted = false
            };
         
            _context.Categories.Add(_category);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateAsync([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(category.Name))
            {
                category.Name = categoryCreateRequest.Name;
            }
            if(!string.IsNullOrEmpty(category.Description))
            {
                category.Description = categoryCreateRequest.Description;
            }
            
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
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

            if(!String.IsNullOrEmpty(categoryCriteria.Search))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(categoryCriteria.Search));
            }
            return categoriesQuery;
        }
        
    }
}
