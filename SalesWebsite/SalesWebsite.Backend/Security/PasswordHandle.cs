namespace SalesWebsite.Backend.Security
{
    public class PasswordHandle
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
