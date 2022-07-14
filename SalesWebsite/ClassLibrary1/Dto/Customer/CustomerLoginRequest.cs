using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.Dto.Customer
{
    public class CustomerLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
