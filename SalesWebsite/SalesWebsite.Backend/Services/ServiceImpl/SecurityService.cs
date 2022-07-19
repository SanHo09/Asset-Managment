using Microsoft.IdentityModel.Tokens;
using SalesWebsite.Backend.Security;
using SalesWebsite.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using SalesWebsite.Shared.Constants;
using System.IdentityModel.Tokens.Jwt;

namespace SalesWebsite.Backend.Services.ServiceImpl
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;

        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PasswordHandle CreatePasswordHash(string password)
        {
            PasswordHandle passwordHandle = new PasswordHandle();
            using (var hmac = new HMACSHA512())
            {
                passwordHandle.PasswordSalt = hmac.Key;
                passwordHandle.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return passwordHandle;
        }

        public bool VerifiPasswordHash(string password, PasswordHandle passwordHashAndSalt)
        {
            using (var hmac = new HMACSHA512(passwordHashAndSalt.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHashAndSalt.PasswordHash);
            }
            return false;
        }

        public string CreateToken(Customer customer)
        {
            var tokenConfig = _configuration[ConfigurationConstants.TOKEN];
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, customer.UserName),
                new Claim(ClaimTypes.Role, customer.IsAdmin ? "Admin" : "Customer"),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenConfig));
            var cerd = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cerd);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        
    }
}
