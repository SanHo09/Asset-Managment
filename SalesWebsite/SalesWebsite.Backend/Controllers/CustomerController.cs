using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Security;
using SalesWebsite.Backend.Services;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerVm>> GetAll()
        {
            return await _customerService.FindAllAsync();
        }   

        [HttpPost]
        public async Task<CustomerVm> Register([FromForm]CustomerCreateRequest customerCreateRequest)
        {
            return await _customerService.RegisterAsync(customerCreateRequest);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromForm]CustomerLoginRequest customerLoginRequest)
        {
            var customer = await _customerService.LoginAsync(customerLoginRequest);
            if(customer == null)
            {
                return NotFound();
            }
            if(customer == "")
            {
                return BadRequest("Wrong password");
            }
            return await _customerService.LoginAsync(customerLoginRequest);
        }

    }
}
