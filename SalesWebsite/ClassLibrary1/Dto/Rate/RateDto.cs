using SalesWebsite.Shared.Dto.Product;
using SalesWebsite.Shared.Dto.Customer;
namespace SalesWebsite.Shared.Dto.Rate
{
    public class RateDto
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public float NumberOfStar { get; set; }

        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
