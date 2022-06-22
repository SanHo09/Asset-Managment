using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Models;
using SalesWebsite.Shared;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SalesWebsiteBackendContext _context;
       

        public CategoryController(SalesWebsiteBackendContext context)
        {
            _context = context;
           
        }

        [HttpGet("/findAll")]
        public IEnumerable<Category> findAll()
        {
            return _context.Categories.Where(i => i.IsDeleted == false);
        }

        [HttpPost("/create")]
        public IActionResult create(CategoryCreateRequest categoryCreateRequest)
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
        public async Task<IActionResult> updateAsync(int id, CategoryCreateRequest categoryCreateRequest)
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

        
    }
}
