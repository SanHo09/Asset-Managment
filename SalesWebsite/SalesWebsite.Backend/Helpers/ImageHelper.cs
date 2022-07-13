namespace SalesWebsite.Backend.Helpers
{
    public class ImageHelper
    {
        private const string IMAGE_FOLDER_NAME = "images";
        public static string GetFileUrl(string fileName)
        {
            var url = string.Empty;
            if (!string.IsNullOrEmpty(fileName)) url = $"{GetImageUrl()}//{fileName}";
            return url;
        }

        public static string GetImageFolderPath()
        {
            return Path.Combine(WebHostHelper.GetWebRootPath(), IMAGE_FOLDER_NAME);

        }

        public static string GetImageUrl()
        {
            return $"{WebHostHelper.GetWebUrl()}//{IMAGE_FOLDER_NAME}";
        }
    }
}
