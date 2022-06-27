using System.Net.Http;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Category;

namespace SalesWebsite.CustomerSite.Services.ServicesImplement
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<PagedResponseDto<CategoryDto>> GetCategoriesAsync(CategoryCriteriaDto categoryCriteriaDto)
        {
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var getCategoryEndpoint = String.IsNullOrEmpty(categoryCriteriaDto.Search) ? 
                                                EndpointConstants.getCategories : 
                                                $"{EndpointConstants.getCategories}?Search={categoryCriteriaDto.Search}";
            var respone = await client.GetAsync(getCategoryEndpoint);
            respone.EnsureSuccessStatusCode();
            var pagedCategory = await respone.Content.ReadAsAsync<PagedResponseDto<CategoryDto>>();
            return pagedCategory;
        }

        public Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
