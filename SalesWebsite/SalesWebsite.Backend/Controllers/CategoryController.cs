using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Shared;
using SalesWebsite.ViewModels;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using Microsoft.AspNetCore.Cors;
using SalesWebsite.Backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<PagedResponseDto<CategoryDto>> FindAllAsync([FromQuery] CategoryCriteriaDto categoryCriteriaDto)
        {
            var page = await _categoryService.FindAllAsync(categoryCriteriaDto);
            return page;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> FindByID(int id)
        {
            var categoryVm = await _categoryService.FindByID(id);
            if (categoryVm == null)
            {
                return NotFound();
            }
            return Ok(categoryVm);

        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            if(categoryCreateRequest.Name == null)
            {
                return BadRequest();
            }
            var categoryVm = await _categoryService.Create(categoryCreateRequest);
            return Ok(categoryVm);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var categoryVm = await _categoryService.UpdateAsync(id, categoryCreateRequest);
            if (categoryVm == null)
            {
                return NotFound();
            }
            return Ok(categoryVm);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var categoryVm = await _categoryService.DeleteAsync(id);
            if (categoryVm == null)
            {
                return NotFound();
            }
            return Ok(categoryVm);
        }


    }
}
