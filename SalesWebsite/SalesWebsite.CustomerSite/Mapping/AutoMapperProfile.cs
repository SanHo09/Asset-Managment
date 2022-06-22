using AutoMapper;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, CategoryVm>().ReverseMap();
            CreateMap<ProductDto, ProductVm>().ReverseMap();
        }
    }
}
