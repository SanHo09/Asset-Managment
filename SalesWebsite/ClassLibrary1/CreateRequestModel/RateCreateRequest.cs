using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.CreateRequest
{
    public class RateCreateRequest
    {
        public string? Content { get; set; }
        public float NumberOfStar { get; set; }

        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}
