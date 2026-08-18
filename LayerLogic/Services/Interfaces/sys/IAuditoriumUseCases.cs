using ATIEnvioSMS.LayerData.Models.DTOs.sys;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.sys
{
    public interface IAuditoriumUseCases
    {
        Task<IEnumerable<AuditoriumDTO>> ObtenerTodosLosLogAsync(CancellationToken cancellationToken);
        Task AgregarLogAsync(CreateAuditoriumDTO logDTO, CancellationToken cancellationToken);
    }
}
