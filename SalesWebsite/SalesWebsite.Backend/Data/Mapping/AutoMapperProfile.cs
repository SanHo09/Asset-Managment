using AutoMapper;
using SalesWebsite.Models;
using SalesWebsite.Shared.Dto.Category;

namespace SalesWebsite.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
