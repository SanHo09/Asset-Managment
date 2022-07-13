
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebsite.Backend.Services;

namespace SalesWebsite.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;

        public ImageController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetImage(string name)
        {
            byte[] b = await _fileStorageService.GetFileAsync(name);
            return File(b, "image/png");
        }
    }
}
