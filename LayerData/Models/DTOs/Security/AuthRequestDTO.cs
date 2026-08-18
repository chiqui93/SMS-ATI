namespace ATIEnvioSMS.LayerData.Models.DTOs.Security
{
    public class AuthRequestDTO
    {
        public required string Usuario { get; set; } = null!;
        public required string Password { get; set; } = null!;
    }
}
