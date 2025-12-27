using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App_Hexagonal.Application.user.ports.output;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App_Hexagonal.Infrastructura.auth.adapter;

public class JwtTokenAdapter : IAuthTokenPort
{
    private readonly IConfiguration _config;
    public JwtTokenAdapter(IConfiguration config)
    {
        _config = config;
    }
    public string GenerateToken(Guid userId, Guid tenantId, string email, IReadOnlyList<string> roles)
    {
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub,userId.ToString()),
            new ("tenant_id",tenantId.ToString()),
            new(JwtRegisteredClaimNames.Email,email)
        };

        foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                int.Parse(_config["Jwt:ExpiresInMinutes"]!)
            ),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
