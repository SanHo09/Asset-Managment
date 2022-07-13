using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services
{
    public interface IRateService
    {
        Task<IEnumerable<RateVm>> GetRates();
        Task<IEnumerable<RateVm>> FindRateByProductId(int productId);
        Task<RateVm> CreateAsync(RateCreateRequest rateCreateRequest);
        Task<RateVm> UpdateAsync(RateCreateRequest rateCreateRequest);
        Task<RateVm> DeleteAsync(int id);
        
    }
}
