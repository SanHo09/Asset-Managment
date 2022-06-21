using SalesWebsite.Shared.Dto.Rate;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Shared.Dto.Customer
{
    public class CustomerDto
    {

        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Isdeleted { get; set; } = true;

        virtual public List<RateDto> rates { get; set; }
    }
}
