using AutoMapper;
using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.CustomerSite.ViewModel.Paged;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVm>().ReverseMap();

            CreateMap<CategoryDto, CategoryVm>().ReverseMap();
            CreateMap<PagedResponseDto<CategoryDto>, PagedResponseVm<CategoryVm>>().ReverseMap();


            CreateMap<ProductDto, ProductVm>().ReverseMap();
            CreateMap<PagedResponseDto<ProductDto>, PagedResponseVm<ProductVm>>().ReverseMap();
        }
    }
}
