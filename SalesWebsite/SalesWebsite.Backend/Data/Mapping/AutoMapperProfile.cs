using AutoMapper;
using SalesWebsite.Models;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Shared.Dto.Rate;

namespace SalesWebsite.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Rate, RateDto>();
        }
    }
}
