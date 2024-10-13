using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Model;

namespace Repository;

public class Auth
{
    public interface IAuthRepository
    {
        string Login(string userName, string password);
    }

    public sealed class AuthRepository : IAuthRepository
    {
        private readonly KoiFishAuctionDbContext _context;
        private readonly IConfiguration _config;


        public AuthRepository(KoiFishAuctionDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Login(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.ToLower() == userName.ToLower() &&
                                                          x.Password == password);
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User? user)
        {
            if (user == null)
            {
                return null;
            }

            var key = _config.GetSection("JWTSection:SecretKey").Value;
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}