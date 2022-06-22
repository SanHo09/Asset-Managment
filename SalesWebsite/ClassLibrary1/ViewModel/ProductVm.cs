using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.ViewModels
{
    public class ProductVm
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

        virtual public CategoryVm Category { get; set; }
        virtual public List<RateVm> Rates {get; set;}
    }
}
