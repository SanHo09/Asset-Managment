using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public float Rate { get; set; }
        public bool IsDeleted { get; set; }
        public int? Sold { get; set; } = 0;

        virtual public Category Category { get; set; }
        virtual public List<Rate> Rates {get; set;}
    }
}
