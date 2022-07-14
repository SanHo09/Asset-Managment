using SalesWebsite.Backend.Security;
using SalesWebsite.Models;

namespace SalesWebsite.Backend.Services
{
    public interface ISecurityService
    {
        PasswordHandle CreatePasswordHash(string password);
        bool VerifiPasswordHash(string password, PasswordHandle passwordHash);                        
        string CreateToken(Customer customer);

    }
}
