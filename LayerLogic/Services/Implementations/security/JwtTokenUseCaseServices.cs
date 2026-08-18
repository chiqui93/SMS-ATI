using ATIEnvioSMS.LayerData.Models.DTOs.Security;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.security
{
    public class JwtTokenUseCaseServices : IJwtTokenUseCases
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenUseCaseServices(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        }
        public string GenerateAccessToken(UsuarioDTO usuario)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, usuario.Idusuario.ToString()),
                new(ClaimTypes.Name, usuario.NombUsuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwtSettings.TokenExpiryHours),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
