using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApi.Models
{
    public class CreateToken
    {
        public string TokenCreate(string userid)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BlogProjectBlogProject"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
              {
                   new Claim(ClaimTypes.NameIdentifier, userid)
               };
            var token = new JwtSecurityToken(issuer: "https://localhost:7216/", audience: "https://localhost:7216/",claims:claims, expires: DateTime.Now.AddHours(2), signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string TokenCreateAdmin(string userid)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BlogProjectBlogProject"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim (ClaimTypes.NameIdentifier,userid),
                new Claim (ClaimTypes.Role, "Admin"),
                
            };
            var token = new JwtSecurityToken(issuer: "https://localhost:7216/", audience: "https://localhost:7216/", claims: claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
