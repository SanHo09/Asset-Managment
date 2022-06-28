using AutoMapper;
using SalesWebsite.Models;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Shared.Dto.Rate;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryVm>();

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductVm>();

            CreateMap<Rate, RateDto>();
            CreateMap<Rate, RateVm>();


        }
    }
}
