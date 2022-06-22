using System.ComponentModel.DataAnnotations;

namespace SalesWebsite.Shared
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}