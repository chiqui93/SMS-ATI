using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.sys
{
    public class UsuarioUseCaseServices : IUsuarioUseCases
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioUseCaseServices(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioDTO>> ObtenerTodosLosUsuariosAsync(CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO?> ObtenerUsuarioByIdAsync(int idusuario, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(idusuario, cancellationToken).ConfigureAwait(false);
            if (usuario == null)
                return null;
            return _mapper.Map<UsuarioDTO>(usuario);
        }
        public async Task AgregarUsuarioAsync(CreateUsuarioDTO usuarioDTO, CancellationToken cancellationToken)
        {
            usuarioDTO.AsignarFecha();
            var usuarioNuevo = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.AddAsync(usuarioNuevo, cancellationToken).ConfigureAwait(false);
        }

        public async Task ActualizarUsuarioAsync(int idusuario, UpdateUsuarioDTO usuarioDTO, CancellationToken cancellationToken)
        {
            usuarioDTO.AsignarFechaAct();
            var usuarioOriginal = await _usuarioRepository.GetByIdAsync(idusuario, cancellationToken).ConfigureAwait(false);
            if (usuarioOriginal is not null)
            {
                usuarioDTO.AsignarFecha(usuarioOriginal.Fecha);
                var usuarioEdit = _mapper.Map<Usuario>(usuarioDTO);

                usuarioEdit.Idusuario = usuarioOriginal.Idusuario;
                usuarioEdit.IdusuarioAgrega = usuarioOriginal.IdusuarioAgrega;

                await _usuarioRepository.UpdateAsync(usuarioEdit, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task EliminarUsuarioAsync(int idusuario, CancellationToken cancellationToken)
             => await _usuarioRepository.DeleteAsync(idusuario, cancellationToken).ConfigureAwait(false);


        public async Task<UsuarioDTO?> VerificarUsuarioAsync(string usuario, string password, CancellationToken cancellationToken)
            => _mapper.Map<UsuarioDTO>(await _usuarioRepository.VerifyUserAsync(usuario, password, cancellationToken).ConfigureAwait(false));
    }
}
