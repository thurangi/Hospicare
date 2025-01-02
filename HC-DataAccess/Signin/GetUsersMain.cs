using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HC_DataAccess.Data;
using HC_DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HC_DataAccess.Signin;

public class GetUsersMain
{
    private readonly IConfiguration _configuration;
    private readonly HCDbContext _hCDbContext;
    public GetUsersMain(IConfiguration configuration, HCDbContext hCDbContext)
    {
        _configuration = configuration;
        _hCDbContext = hCDbContext;
    }
    public void GetEntities(SigninModel signinModel, out string result)
    {
        
        User user = _hCDbContext.Users.FirstOrDefault(u => u.Username == signinModel.UserName)!;
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(signinModel.Password, user.PasswordHash);
 
        if (signinModel.UserName == user.Username && isPasswordValid)
        {
            // Generate JWT Token
            result = GenerateJwtToken(signinModel.UserName);
            return;
        }
        result = "not success";
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
