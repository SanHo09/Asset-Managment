using SalesWebsite.CustomerSite.ViewModel;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Dto.Product;

namespace SalesWebsite.CustomerSite.Services.ServicesImplement
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<PagedResponseDto<ProductDto>> GetProductAsync(ProductCriteriaDto productCriteriaDto)
        {
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var getProductEndpoint = String.IsNullOrEmpty(productCriteriaDto.Search) ?
                                        EndpointConstants.getProducts :
                                        $"{EndpointConstants.getProducts}?Search={productCriteriaDto.Search}";
            var response = await client.GetAsync(getProductEndpoint);
            response.EnsureSuccessStatusCode();
            var pagedResponse = await response.Content.ReadAsAsync<PagedResponseDto<ProductDto>>();
            return pagedResponse;
        }

        public Task<ProductVm> GetProductByCategoryAsync(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVm> GetProductByIdAsync(int productId)
        {
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var getProductEndpoint = $"{EndpointConstants.getProducts}/{productId}";
            var response = await client.GetAsync(getProductEndpoint);
            response.EnsureSuccessStatusCode();
            var productVm = await response.Content.ReadAsAsync<ProductVm>();
            return productVm;
        }
    }
}
