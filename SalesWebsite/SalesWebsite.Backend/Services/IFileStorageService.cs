namespace SalesWebsite.Backend.Services
{
     public interface IFileStorageService
    {
         string GetImageFolderPath();
         Task<string> SaveFileAsync(IFormFile file);
         Task<Byte[]> GetFileAsync(string fileName);

    }
}
