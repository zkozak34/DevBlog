using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevBlog.Service.Utilities.Security
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        public string Authenticate(int id, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(ServiceRegistration.SaltKey); // secret token key
            var tokenDescriptor = new SecurityTokenDescriptor // token descriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.PrimarySid, id.ToString()),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static IDictionary<string, string> Decode(string token)
        {
            var userInfoFromToken = new Dictionary<string, string>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodeToken = tokenHandler.ReadJwtToken(token);
            userInfoFromToken.Add("userId", decodeToken.Claims.First(claim => claim.Type == ClaimTypes.PrimarySid).ToString());
            userInfoFromToken.Add("email", decodeToken.Claims.First(claim => claim.Type == ClaimTypes.Email).ToString());
            return userInfoFromToken;
        }
    }
}
