using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Data;
using SalesWebsite.Models;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly SalesWebsiteBackendContext _context;
        private readonly IMapper _mapper;
        public RateController(SalesWebsiteBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> createAsync(RateCreateRequest rateCreateRequest)
        {
            Customer customer = await _context.Customers.FindAsync(rateCreateRequest.CustomerId);
            Product product = await _context.Products.FindAsync(rateCreateRequest.ProductId);
            if(customer == null  || product == null)
            {
                return NotFound();
            }
            Rate rate = new Rate()
            {
                Content = rateCreateRequest.Content,
                Customer = customer,
                Product = product,
                NumberOfStar = rateCreateRequest.NumberOfStar, 
            };
            _context.Rates.Add(rate);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Rate> GetRates()
        {
            return _context.Rates.ToList();
        }

        
   }
}
