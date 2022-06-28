using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.ViewModels;
using SalesWebsite.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using SalesWebsite.Backend.Extensions;
using Microsoft.AspNetCore.Cors;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.Backend.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;

        public ProductController(SalesWebsiteBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("findByCategory/{categoryId}")]
        public IEnumerable<Product> FindByCategoryId(int id)
        {
            return _context.Products.Include(p => p.Category);
        }

        [HttpGet]
        public async Task<PagedResponseDto<ProductDto>> FindAllAsync([FromQuery]ProductCriteriaDto productCriteriaDto)
        {
            var productQuery = _context.Products
                .Include(p => p.Category)
                .Where(i => !i.IsDeleted)
                .AsQueryable();

            productQuery = ProductFilter(productQuery, productCriteriaDto);

            var pagedProducts = await productQuery
                .AsNoTracking()
                .paginateAsync(productCriteriaDto);

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts.Items);
            return new PagedResponseDto<ProductDto>
            {
                CurrentPage = pagedProducts.CurrentPage,
                TotalPages = pagedProducts.TotalPages,
                TotalItems = pagedProducts.TotalItems,
                Search = productCriteriaDto.Search,
                SortColumn = productCriteriaDto.SortColumn,
                SortOrder = productCriteriaDto.SortOrder,
                Limit = productCriteriaDto.Limit,
                Items = productDto
            };
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(i => i.Id == id && !i.IsDeleted);
            if(product == null)
            {
                return NotFound();
            }
          
            return Ok(new ProductVm
            {
                Id = product.Id,
                Name = product.Name,
                CreatedDate = product.CreatedDate,
                UpdateDate = product.UpdateDate,
                image = product.image,
                Quantity = product.Quantity,
                Price = product.Price,
                Rate = product.Rate,
                Sold = product.Sold,

                Category = _mapper.Map<CategoryVm>(product.Category),
                Rates = _mapper.Map<List<RateVm>>(product.Rates)


            }); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]ProductCreateRequest productCreateRequest)
        {
            var category = await _context.Categories.FindAsync(productCreateRequest.CategoryId);
            if(category == null)
            {
                return NotFound();
            }
            var product = new Product()
            {
                Name = productCreateRequest.Name,
                Price = productCreateRequest.Price,
                Quantity = productCreateRequest.Quantity,
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsDeleted = false,
                Rate = 0,
                image = productCreateRequest.image,
                Sold = productCreateRequest.Sold,
                Category = category,
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);
            var category = await _context.Categories.FindAsync(productCreateRequest.CategoryId);
          
            if(product == null || category == null)
            {
                return NotFound();
            }
            if(!String.IsNullOrEmpty(productCreateRequest.Name))
            {
                product.Name = productCreateRequest.Name;
            } 
            if(productCreateRequest.Price > 0)
            {
                product.Price = productCreateRequest.Price;
            }
            if(productCreateRequest.Quantity > 0)
            {
                product.Quantity = productCreateRequest.Quantity;
            }
            if(productCreateRequest.Rate > 0 )
            {
                product.Rate = productCreateRequest.Rate;
            }
            if(!string.IsNullOrEmpty(productCreateRequest.image))
            {
                product.image = productCreateRequest.image;
            }
            product.Category = category;
            product.UpdateDate = new DateTime();
           
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDeleted = true;
            _context.Products.Update(product);
            return Ok();
        }

        private IQueryable<Product> ProductFilter(
            IQueryable<Product> productQuery,
            ProductCriteriaDto productCriteria)
        {
            if(!String.IsNullOrEmpty(productCriteria.Search))
            {
                productQuery = productQuery.Where(i => i.Name.Contains(productCriteria.Search) ||
                                                        i.Id.ToString().Contains(productCriteria.Search));
            }
            return productQuery;
        }
       
    }

}
