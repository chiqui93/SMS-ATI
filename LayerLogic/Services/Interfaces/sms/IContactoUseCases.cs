using ATIEnvioSMS.LayerData.Models.DTOs.sms;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.sms
{
    public interface IContactoUseCases
    {
        Task<IEnumerable<ContactoDTO>> ObtenerTodosContactosAsync(CancellationToken cancellationToken);
        Task<ContactoDTO?> ObtenerContactoByIdAsync(int idcontacto, CancellationToken cancellationToken);
        Task AgregarContactoAsync(CreateContactoDTO contactoDTO, CancellationToken cancellationToken);
        Task ActualizarContactoAsync(int idcontacto, UpdateContactoDTO contactoDTO, CancellationToken cancellationToken);
        Task EliminarContactoAsync(int idcontacto, CancellationToken cancellationToken);
    }
}
