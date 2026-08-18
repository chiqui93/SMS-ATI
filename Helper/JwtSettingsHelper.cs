using ATIEnvioSMS.LayerData.Models.DTOs.Security;

namespace ATIEnvioSMS.Helper
{
    public static class JwtSettingsHelper
    {
        public static JwtSettings GetJwtSettingsFromEnvironment(WebApplicationBuilder builder)
        {
            return new JwtSettings
            {
                Key = Environment.GetEnvironmentVariable("JwtSettings__Key")
                ?? builder.Configuration["JwtSettings:Key"]
                ?? throw new InvalidOperationException("Jwt Key No Configurada"),

                Issuer = Environment.GetEnvironmentVariable("JwtSettings__Issuer")
                ?? builder.Configuration["JwtSettings:Issuer"]
                ?? throw new InvalidOperationException("Jwt Issuer No Configurada"),

                Audience = Environment.GetEnvironmentVariable("JwtSettings__Audience")
                ?? builder.Configuration["JwtSettings:Audience"]
                ?? throw new InvalidOperationException("Jwt Audience No Configurada"),

                TokenExpiryHours = int.Parse(Environment.GetEnvironmentVariable("JwtSettings__TokenExpiryHours")
                ?? builder.Configuration["JwtSettings:TokenExpiryHours"]
                ?? "1"),
            };
        }
    }
}
