using SalesWebsite.Backend.Helpers;
using SalesWebsite.Shared.Constants;
using System.Net.Http.Headers;

namespace SalesWebsite.Backend.Services
{
    public class FileStorageService :IFileStorageService
    {

        private readonly string _imageFolderPath;
        private readonly IConfiguration _configuration;
        private const string IMAGE_FOLDER_NAME = "images";
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileStorageService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _imageFolderPath = $"{_webHostEnvironment.WebRootPath}\\{IMAGE_FOLDER_NAME}"; 
        }

        public string GetImageFolderPath()
        {
            return _imageFolderPath;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var path = _imageFolderPath;
            string fileUrl = $"{path}//{file.FileName}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(fileUrl))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return $"{_configuration[ConfigurationConstants.BACK_END_ENDPOINT]}/{EndpointConstants.getImage}/{file.FileName}";
        }
        public async Task<Byte[]> GetFileAsync(string fileName)
        {
            string fileUrl = $"{_imageFolderPath}\\{fileName}";
            if (System.IO.File.Exists(fileUrl))
            {
                byte[] imageToByte = await System.IO.File.ReadAllBytesAsync(fileUrl);
                return imageToByte;
            } else
            {
                return null;
            }
        }

    }
}
