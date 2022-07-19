using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Shared.Dto;
using Microsoft.AspNetCore.Cors;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Backend.Services;
using SalesWebsite.Shared.CreateRequest;
using Microsoft.AspNetCore.Authorization;

namespace SalesWebsite.Backend.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<PagedResponseDto<ProductDto>> FindAllAsync([FromQuery] ProductCriteriaDto productCriteriaDto)
        {
            return await _productService.FindAllAsync(productCriteriaDto);
            
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> FindById(int id)
        {
            var productVm = await _productService.FindById(id);
            if(productVm == null)
            {
                return NotFound();
            }
            return Ok(productVm);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateRequest productCreateRequest)
        {
            var productVm = await _productService.CreateAsync(productCreateRequest);
            if (productVm == null)
            {
                return NotFound();
            }
            return Ok(productVm);
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductCreateRequest productCreateRequest)
        {
            var productVm = await _productService.UpdateAsync(id, productCreateRequest);
            if (productVm == null)
            {
                return NotFound();
            }
            return Ok(productVm);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productVm = await _productService.DeleteAsync(id);
            if (productVm == null)
            {
                return NotFound();
            }
            return Ok(productVm);
        }
    }
}
