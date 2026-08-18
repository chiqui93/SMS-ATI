namespace ATIEnvioSMS.LayerData.Models.DTOs.Security
{
    public class AuthResponseDTO
    {
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public string AuthToken { get; set; } = null!;
        public bool IsSuperAdmin { get; set; }
        public bool IsAdmin { get; set; }
    }
}
