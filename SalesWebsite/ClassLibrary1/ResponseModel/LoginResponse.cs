namespace SalesWebsite.Shared.ResponseModels
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
