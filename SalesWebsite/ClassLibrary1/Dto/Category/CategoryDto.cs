using SalesWebsite.Shared.Dto.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Shared.Dto.Category
{
    public class CategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        virtual public List<ProductDto> Products { get; set; }
    }
}
