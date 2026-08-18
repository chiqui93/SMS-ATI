using ATIEnvioSMS.LayerData.Models.DTOs.sys;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.security
{
    public interface IJwtTokenUseCases
    {
        string GenerateAccessToken(UsuarioDTO usuario);
    }
}
