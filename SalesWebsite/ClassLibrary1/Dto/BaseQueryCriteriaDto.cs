using SalesWebsite.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebsite.Shared.Dto
{
    // Class tiêu chuẩn, chứa những thông số cơ bản
    public class BaseQueryCriteriaDto
    {
        public string Search { get; set; }
        public SortOrderEnum SortOrder { get; set; }
        public string SortColumn { get; set; }
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
