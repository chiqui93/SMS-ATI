namespace ATIEnvioSMS.LayerData.Models.DTOs.Security
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string Key { get; set; } = null!;
        public int TokenExpiryHours { get; set; }
    }
}
