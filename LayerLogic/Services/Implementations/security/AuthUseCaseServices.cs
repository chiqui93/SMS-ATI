using ATIEnvioSMS.LayerData.Models.DTOs.Security;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.security;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.security
{
    public class AuthUseCaseServices : IAuthUseCases
    {
        private readonly IAuditoriumUseCases _logServicio;
        private readonly IJwtTokenUseCases _jwtTokenServices;
        private readonly IUsuarioUseCases _usuarioServices;

        public AuthUseCaseServices(IJwtTokenUseCases jwtTokenServices, IUsuarioUseCases usuarioServices, IAuditoriumUseCases logServicio)
        {
            _jwtTokenServices = jwtTokenServices;
            _usuarioServices = usuarioServices;
            _logServicio = logServicio;
        }

        public async Task<AuthResponseDTO> AutenticarUsuarioAsync(AuthRequestDTO authRequestDTO, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(authRequestDTO);

            var usuario = await _usuarioServices.VerificarUsuarioAsync(authRequestDTO.Usuario, authRequestDTO.Password, cancellationToken)
                ?? throw new KeyNotFoundException("No se encontro el usuario");

            var logNew = new CreateAuditoriumDTO
            {
                Idusuario = usuario.Idusuario,
                Descripcion = "Usuario autenticado con éxito",
                DireccionIp = ""
            };

            await _logServicio.AgregarLogAsync(logNew, cancellationToken);

            var accessToken = _jwtTokenServices.GenerateAccessToken(usuario);

            return new AuthResponseDTO
            {
                IdUsuario = usuario.Idusuario,
                AuthToken = accessToken,
                IsAdmin = usuario.Isadmin,
                IdEmpresa = !usuario.IssuperAdmin ? usuario.Idempresa : null,
                IsSuperAdmin = usuario.IssuperAdmin
            };
        }
    }
}
