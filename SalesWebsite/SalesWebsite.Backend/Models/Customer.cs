using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Isdeleted { get; set; } = true;

        public virtual List<Rate> rates { get; set; }
    }
}
