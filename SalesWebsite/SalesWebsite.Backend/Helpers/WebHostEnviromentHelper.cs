namespace SalesWebsite.Backend.Helpers
{
    public static class WebHostHelper
    {

        public static string GetWebRootPath()
        {
            var _accessor = new HttpContextAccessor();

            return _accessor.HttpContext
                               .RequestServices
                               .GetRequiredService<IConfiguration>()
                               .GetValue<string>("EndPoints:BackEnd");

        }
        public static string GetWebUrl()
        {
            var _accessor = new HttpContextAccessor();

            return _accessor.HttpContext
                               .RequestServices
                               .GetRequiredService<IConfiguration>()
                               .GetValue<string>("EndPoints:BackEnd");
        }

    }
}
