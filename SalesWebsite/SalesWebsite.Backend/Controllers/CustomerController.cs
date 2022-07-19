using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Backend.Security;
using SalesWebsite.Backend.Services;
using SalesWebsite.Models;
using SalesWebsite.Shared;
using SalesWebsite.Shared.CreateRequest;
using SalesWebsite.Shared.Dto.Customer;
using SalesWebsite.Shared.ResponseModels;
using SalesWebsite.ViewModels;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IEnumerable<CustomerVm>> GetAll()
        {
            return await _customerService.FindAllAsync();
        }   

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerVm>> Register(CustomerCreateRequest customerCreateRequest)
        {
            try
            {
                var customer = await _customerService.RegisterAsync(customerCreateRequest);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch
            {
                return BadRequest("2 mật khẩu không trùng nhau");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(CustomerLoginRequest customerLoginRequest)
        {
            try
            {
                var customer = await _customerService.LoginAsync(customerLoginRequest);
                if (customer == null)
                {
                    return NotFound();
                }
            } catch
            {
                return BadRequest("Wrong password");
            }
            return await _customerService.LoginAsync(customerLoginRequest);
        }

    }
}
