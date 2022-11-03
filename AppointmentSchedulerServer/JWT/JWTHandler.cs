using AppointmentSchedulerServer.Data_Transfer_Objects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppointmentSchedulerServerTests.JWT
{
    public class JWTHandler
    {
        public const string jwtString = "this is the jwt token string";
        public static string CreateUserToken(AccountDTO account)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, "User")
                };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtString));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string CreateAdminToken(AccountDTO account)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtString));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
