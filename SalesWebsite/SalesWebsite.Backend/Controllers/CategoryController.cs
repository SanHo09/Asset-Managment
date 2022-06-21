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
        public IActionResult findAll()
        {
            return Ok(_context.Categories.Where(i => i.IsDeleted == false));
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

        
    }
}
