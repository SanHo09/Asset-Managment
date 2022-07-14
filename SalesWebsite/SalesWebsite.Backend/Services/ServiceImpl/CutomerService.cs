using AutoMapper;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Security;
using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Services.ServiceImpl
{
    public class CutomerService : ICustomerService
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        public CutomerService(SalesWebsiteBackendContext context, ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerVm>> FindAllAsync()
        {
            var customer = _context.Customers.Where(c => !c.Isdeleted).ToList();
            var customerVm = _mapper.Map<IEnumerable<CustomerVm>>(customer);
            return customerVm;
        }

        public async Task<string> LoginAsync(CustomerLoginRequest customerLoginRequest)
        {
            var customer = _context.Customers.FirstOrDefault(customer =>
                                            customer.UserName == customerLoginRequest.UserName);

            if (customer == null)
            {
                return null;
            }

            var passwordHandle = new PasswordHandle()
            {
                PasswordHash = customer.PasswordHash,
                PasswordSalt = customer.PasswordSalt
            };

            if (!_securityService.VerifiPasswordHash(customerLoginRequest.Password, passwordHandle))
            {
                return "";
            }

            return _securityService.CreateToken(customer);
        }

        public Task<CustomerVm> RegisterAsync(CustomerCreateRequest customerCreateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
