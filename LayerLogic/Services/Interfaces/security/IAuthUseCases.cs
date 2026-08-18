using ATIEnvioSMS.LayerData.Models.DTOs.Security;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.security
{
    public interface IAuthUseCases
    {
        Task<AuthResponseDTO> AutenticarUsuarioAsync(AuthRequestDTO authRequestDTO, CancellationToken cancellationToken);
    }
}
