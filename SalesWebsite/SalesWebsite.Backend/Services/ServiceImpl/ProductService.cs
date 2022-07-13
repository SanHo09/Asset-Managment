using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Extensions;
using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services.ServiceImpl
{
    public class ProductService : IProductService
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IFileStorageService _fileStorageService;

        public ProductService(SalesWebsiteBackendContext context, IMapper mapper, IConfiguration configuration, IFileStorageService fileStorageService)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _fileStorageService = fileStorageService;
        }

        public async Task<PagedResponseDto<ProductDto>> FindAllAsync(ProductCriteriaDto productCriteriaDto)
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

        public async Task<ProductVm> FindById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Rates).ThenInclude(r => r.Customer).Where(i => !i.IsDeleted)
                .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            if (product == null)
            {
                return null;
            }

            return new ProductVm
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
            };
        }

        public async Task<ProductVm> CreateAsync(ProductCreateRequest productCreateRequest)
        {
            var category = await _context.Categories.FindAsync(productCreateRequest.CategoryId);
            if (category == null)
            {
                return null;
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
                image = await _fileStorageService.SaveFileAsync(productCreateRequest.image),
                Sold = productCreateRequest.Sold,
                Category = category,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductVm
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
            };
        }

        public async Task<ProductVm> UpdateAsync(int id, ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);
            var category = await _context.Categories.FindAsync(productCreateRequest.CategoryId);

            if (product == null || category == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(productCreateRequest.Name))
            {
                product.Name = productCreateRequest.Name;
            }
            if (productCreateRequest.Price > 0)
            {
                product.Price = productCreateRequest.Price;
            }
            if (productCreateRequest.Quantity >= 0)
            {
                product.Quantity = productCreateRequest.Quantity;
            }
            if (productCreateRequest.Rate >= 0)
            {
                product.Rate = productCreateRequest.Rate;
            }
            if (productCreateRequest.image != null)
            {
                product.image = await _fileStorageService.SaveFileAsync(productCreateRequest.image);
            }
            if (productCreateRequest.Sold >= 0)
            {
                product.Sold = productCreateRequest.Sold;
            }
            product.Category = category;
            product.UpdateDate = DateTime.Now;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new ProductVm
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
            };
        }

        public async Task<ProductVm> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.IsDeleted = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new ProductVm
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
            };
        }

        public IQueryable<Product> ProductFilter(IQueryable<Product> productQuery, ProductCriteriaDto productCriteria)
        {
            if (!String.IsNullOrEmpty(productCriteria.Search))
            {
                productQuery = productQuery.Where(i => i.Name.Contains(productCriteria.Search) ||
                                                        i.Id.ToString().Contains(productCriteria.Search));
            }
            return productQuery;
        }

    }
}
