using SalesWebsite.Shared.Dto;
using SalesWebsite.Shared.Enum;
using SalesWebsite.Shared.Constants;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace SalesWebsite.Backend.Extensions
{
    // Chuyển dữ liệu thành Page và phân trang
    public static class DataPagerExtensions
    {
        public static async Task<PagedModelDto<TModel>> paginateAsync<TModel> (
            //This có thể dùng trực tiếp trong queryAble mà ko cần khởi tạo
            this IQueryable<TModel> query, 
            BaseQueryCriteriaDto criteriaDto)
            where TModel : class
        {
            var paged = new PagedModelDto<TModel>();

            // Kiểm tra trang hiện tại và sắp xếp theo cột
            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;
            if(!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
               !string.IsNullOrEmpty(criteriaDto.SortColumn)) { 

                var sortOrder = criteriaDto.SortOrder == SortOrderEnum.Ascending ? 
                    PagingSortingConstants.ASC : 
                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query.OrderBy(orderString); // dùng linq Dynamic

            }

            // Bỏ qua dòng đầu tiên
            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query.Skip(startRow)
                .Take(paged.PageSize)
                .ToListAsync();
            paged.TotalItems = paged.Items.Count;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
        
    }
}
