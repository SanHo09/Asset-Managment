using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.Dto
{
    // Class dùng để trả về cho view
    public class PagedResponseDto<TModel> : BaseQueryCriteriaDto
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TModel> Items { get; set; }
    }
}
