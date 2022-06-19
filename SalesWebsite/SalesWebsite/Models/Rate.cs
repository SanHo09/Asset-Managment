using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Models
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public float NumberOfStar { get; set; }

        virtual public List<Product> Products { get; set; }
        virtual public List<Customer> Customers { get; set; }
    }
}
