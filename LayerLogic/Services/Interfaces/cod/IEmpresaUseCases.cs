using ATIEnvioSMS.LayerData.Models.DTOs.cod;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.cod
{
    public interface IEmpresaUseCases
    {
        Task<IEnumerable<EmpresaDTO>> ObtenerTodasEmpresasAsync(CancellationToken cancellationToken);
        Task<EmpresaDTO?> ObtenerEmpresaByIdAsync(int idempresa, CancellationToken cancellationToken);
        Task AgregarEmpresaAsync(CreateOrUpdateEmpresaDTO empresaDTO, CancellationToken cancellationToken);
        Task ActualizarEmpresaAsync(int idempresa, CreateOrUpdateEmpresaDTO empresaDTO, CancellationToken cancellationToken);
        Task EliminarEmpresaAsync(int idempresa, CancellationToken cancellationToken);
    }
}
