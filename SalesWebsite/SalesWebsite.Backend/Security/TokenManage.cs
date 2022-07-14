using Microsoft.IdentityModel.Tokens;
using SalesWebsite.Models;
using System.Security.Claims;

namespace SalesWebsite.Backend.Security
{
    public static class TokenManage
    {
        public static string CreateToken(Customer customer)
        { 
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, customer.UserName),
                new Claim(ClaimTypes.Role, customer.IsAdmin ? "admin" : "customer"),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));
            return string.Empty;
        }
    }
}
