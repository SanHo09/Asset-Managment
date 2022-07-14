using SalesWebsite.Shared.Dto.Rate;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebsite.Shared.Dto.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool Isdeleted { get; set; } = true;
        public virtual List<RateDto> Rates { get; set; }
    }
}
