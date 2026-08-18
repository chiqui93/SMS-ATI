using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;

namespace ATIEnvioSMS.LayerLogic.Services.Interfaces.sys
{
    public interface IUsuarioUseCases
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerTodosLosUsuariosAsync(CancellationToken cancellationToken);
        Task<UsuarioDTO?> ObtenerUsuarioByIdAsync(int idusuario, CancellationToken cancellationToken);
        Task AgregarUsuarioAsync(CreateUsuarioDTO usuarioDTO, CancellationToken cancellationToken);
        Task ActualizarUsuarioAsync(int idusuario, UpdateUsuarioDTO usuarioDTO, CancellationToken cancellationToken);
        Task EliminarUsuarioAsync(int idusuario, CancellationToken cancellationToken);
        Task<UsuarioDTO?> VerificarUsuarioAsync(string usuario, string password, CancellationToken cancellationToken);
    }
}
