using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Product> Products { get; set; }
       
    }
}
