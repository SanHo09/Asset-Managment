using SalesWebsite.Shared.Dto.Category;
using SalesWebsite.Shared.Dto.Rate;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Shared.Dto.Product
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public float Rate { get; set; }
        public bool IsDeleted { get; set; }

        virtual public CategoryDto Category { get; set; }
        virtual public List<RateDto> Rates { get; set; }
    }
}
