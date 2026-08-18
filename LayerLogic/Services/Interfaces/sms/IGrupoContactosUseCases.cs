using ATIEnvioSMS.LayerData.Models.DTOs.sms;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.sms
{
    public interface IGrupoContactosUseCases
    {
        Task<IEnumerable<GrupoContactoDTO>> ObtenerGruposDeContactosAsync(CancellationToken cancellationToken);
        Task<GrupoContactoConContactosDTO?> ObtenerGrupoDeContactosByIdAsync(int idcontacto, CancellationToken cancellationToken);
        Task AgregarGrupoDeContactosAsync(CreateGrupoContactosDTO grupoDeContactosDTO, CancellationToken cancellationToken);
        Task ActualizarGrupoDeContactosAsync(int idgrupoDeContactos, UpdateGrupoContactosDTO grupoDeContactoDTO, CancellationToken cancellationToken);
        Task EliminarGrupoDeContactosAsync(int idgrupoDeContactos, CancellationToken cancellationToken);
    }
}
