using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assesment_API_TokaReda.Data;
using Assesment_API_TokaReda.DTOs.Auth;
using Assesment_API_TokaReda.Models;
using Assesment_API_TokaReda.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Assesment_API_TokaReda.Repos.Implmentation
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _conf;
        public AuthRepo(AppDbContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }
        public async Task<string> Login(LoginDTO dto)
        {
           var user= await _context.users.FirstOrDefaultAsync(c=>c.Email==dto.Email);
            if (user == null) { return null; }

            if (user.Password == dto.Password)
            {
                return GenerateToken(user);
            }
            return null;
        }

        public async Task<bool> Register(RegisterDTO dto)
        {
            var u =await _context.users.AnyAsync(c=>c.Email== dto.Email);
            if(u) { return false; }

           
            return true;

        }

        private string GenerateToken(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role),   
                new Claim(ClaimTypes.Email,user.Email),

            };

            var Key=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_conf["JWT:Key"]));
            var sinig = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);

            var tokenobj = new JwtSecurityToken(
                issuer: _conf["JWT:Issuer"],
                audience: _conf["JWT:Audience"],
                signingCredentials:sinig,
                claims:claim,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_conf["JWT:ExpirationInHours"]))
                
                );
            
            var token=new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token;
        }
    }
}
