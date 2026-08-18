using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Implementations.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.cod;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.sms
{
    public class GrupoContactosUseCaseServices : IGrupoContactosUseCases
    {
        private readonly IEmpresaUseCases _empresaServices;
        private readonly IUsuarioUseCases _usuarioServices;
        private readonly IGrupoContactoRepository _grupoContactosRepository;
        private readonly IMapper _mapper;

        public GrupoContactosUseCaseServices(IGrupoContactoRepository grupoContactosRepository,
                                             IEmpresaUseCases empresaServices,
                                             IUsuarioUseCases usuarioServices, IMapper mapper)
        {
            _grupoContactosRepository = grupoContactosRepository;
            _empresaServices = empresaServices;
            _usuarioServices = usuarioServices;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GrupoContactoDTO>> ObtenerGruposDeContactosAsync(CancellationToken cancellationToken)
        {
            var gruposDeContactos = await _grupoContactosRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            var gposContactosDTO = _mapper.Map<IEnumerable<GrupoContactoDTO>>(gruposDeContactos);
            if (gposContactosDTO.Any()) {
                foreach (var grpContacto in gposContactosDTO)
                {
                    grpContacto.Empresa = await ObtenerNombreEmpresaAsync(grpContacto.Idempresa, cancellationToken);
                    grpContacto.UsuarioAgrega = await ObtenerNombreUsuarioAsync(grpContacto.IdusuarioAgrega, cancellationToken);
                    grpContacto.UsuarioAct = await ObtenerNombreUsuarioAsync(grpContacto.IdusuarioAct, cancellationToken);
                }
            }
           return gposContactosDTO;
        }

        public async Task<GrupoContactoConContactosDTO?> ObtenerGrupoDeContactosByIdAsync(int idcontacto, CancellationToken cancellationToken)
        {
            var grupoDeContactos = await _grupoContactosRepository.GetByIdAsync(idcontacto, cancellationToken).ConfigureAwait(false);
            var gpoContactosDTO = _mapper.Map<GrupoContactoConContactosDTO>(grupoDeContactos);

            if (gpoContactosDTO is not null)
            {
                gpoContactosDTO.Empresa = await ObtenerNombreEmpresaAsync(gpoContactosDTO.Idempresa, cancellationToken);
                    gpoContactosDTO.UsuarioAgrega = await ObtenerNombreUsuarioAsync(gpoContactosDTO.IdusuarioAgrega, cancellationToken);
                    gpoContactosDTO.UsuarioAct = await ObtenerNombreUsuarioAsync(gpoContactosDTO.IdusuarioAct, cancellationToken);
            }
            return gpoContactosDTO;
        }

        public async Task AgregarGrupoDeContactosAsync(CreateGrupoContactosDTO grupoDeContactosDTO, CancellationToken cancellationToken)
        {
            grupoDeContactosDTO.AsignarFecha();
            var grupoNuevo = _mapper.Map<GrupoContactos>(grupoDeContactosDTO);
            await _grupoContactosRepository.AddAsync(grupoNuevo, cancellationToken).ConfigureAwait(false);
        }

        public async Task ActualizarGrupoDeContactosAsync(int idgrupoDeContactos, UpdateGrupoContactosDTO grupoDeContactoDTO, CancellationToken cancellationToken)
        {
            var grupoDeContactosModify = await _grupoContactosRepository.GetByIdAsync(idgrupoDeContactos, cancellationToken).ConfigureAwait(false);
            if (grupoDeContactosModify is not null)
            {
                grupoDeContactoDTO.AsignarFechaAct();
                var grupoDeContactosOriginal = grupoDeContactosModify;
                _mapper.Map(grupoDeContactoDTO, grupoDeContactosModify);
                grupoDeContactosModify.Fecha = grupoDeContactosOriginal.Fecha;
                grupoDeContactosModify.IdusuarioAgrega = grupoDeContactosOriginal.IdusuarioAgrega;
                grupoDeContactosModify.IdGrupoContacto = grupoDeContactosOriginal.IdGrupoContacto;

                await _grupoContactosRepository.UpdateAsync(grupoDeContactosModify, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task EliminarGrupoDeContactosAsync(int idgrupoDeContactos, CancellationToken cancellationToken)
        {
            await _grupoContactosRepository.DeleteAsync(idgrupoDeContactos, cancellationToken).ConfigureAwait(false);
        }

        private async Task<string?> ObtenerNombreUsuarioAsync(int IdUsuario, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioServices.ObtenerUsuarioByIdAsync(IdUsuario, cancellationToken).ConfigureAwait(false);
            return usuario?.NombUsuario;
        }

        private async Task<string?> ObtenerNombreEmpresaAsync(int? Idempresa, CancellationToken cancellationToken)
        {
            if (Idempresa.HasValue)
            {
                var empresa = await _empresaServices.ObtenerEmpresaByIdAsync(Idempresa.Value, cancellationToken).ConfigureAwait(false);
                return empresa?.Nombre;
            }
            return string.Empty;
        }
    }
}
