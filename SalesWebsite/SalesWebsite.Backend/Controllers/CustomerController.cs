using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;

        public CustomerController(SalesWebsiteBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerCreateRequest customerCreateRequest)
        {
            var checkCustomer = _context.Customers
                .FirstOrDefault(customer => customer.UserName == customerCreateRequest.UserName);
            if(checkCustomer != null)
            {
                return BadRequest("Username already exists ");
            } 
            Customer customer = new Customer()
            {
                UserName = customerCreateRequest.UserName,
                Password = customerCreateRequest.Password,
                FullName = customerCreateRequest.FullName,
                
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
