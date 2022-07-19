using AutoMapper;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Security;
using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.ViewModels;
using SalesWebsite.Shared.ResponseModels;

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

        public async Task<LoginResponse> LoginAsync(CustomerLoginRequest customerLoginRequest)
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
                throw new Exception("Wrong password");
            }

            return new LoginResponse
            {
                Token = _securityService.CreateToken(customer),
                IsAdmin = customer.IsAdmin,
                UserName = customer.UserName,
                FullName = customer.FullName
            };
        }

        public async Task<CustomerVm> RegisterAsync(CustomerCreateRequest customerCreateRequest)
        {
            var customerCheck = _context.Customers.FirstOrDefault(customer =>
                                            customer.UserName == customerCreateRequest.UserName);
            if (customerCheck != null)
            {
                return null;
            }
            if(customerCreateRequest.Password != customerCreateRequest.ConfirmPassword)
            {
                throw new Exception("2 password Not equals"); 
            }

            var passwordHandle = _securityService.CreatePasswordHash(customerCreateRequest.Password);

            var customer = new Customer()
            {
                UserName = customerCreateRequest.UserName,
                PasswordSalt = passwordHandle.PasswordSalt,
                PasswordHash = passwordHandle.PasswordHash,
                Email = customerCreateRequest.Email,
                FullName = customerCreateRequest.FullName,
                IsAdmin = false,
                Isdeleted = false,
            };

            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
            return new CustomerVm
            {
                Id = customer.Id,
                Email = customer.UserName,
                UserName = customer.UserName,
                FullName = customer.FullName,
            };
        }
    }
}
