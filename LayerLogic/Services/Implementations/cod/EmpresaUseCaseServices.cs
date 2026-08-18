using ATIEnvioSMS.LayerData.Models.DTOs.cod;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Repository.Interfaces.cod;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.cod;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.cod
{
    public class EmpresaUseCaseServices : IEmpresaUseCases
    {
        private readonly IEmpresaRepository _empresaRepositorio;
        private readonly IMapper _mapper;

        public EmpresaUseCaseServices(IEmpresaRepository empresaRepositorio, IMapper mapper)
        {
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresaDTO>> ObtenerTodasEmpresasAsync(CancellationToken cancellationToken)
        {
            var empresas = await _empresaRepositorio.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
        }
        public async Task<EmpresaDTO?> ObtenerEmpresaByIdAsync(int idempresa, CancellationToken cancellationToken)
        {
            var empresa = await _empresaRepositorio.GetByIdAsync(idempresa, cancellationToken).ConfigureAwait(false);
            return empresa is null ? null : _mapper.Map<EmpresaDTO>(empresa);
        }
        public async Task AgregarEmpresaAsync(CreateOrUpdateEmpresaDTO empresaDTO, CancellationToken cancellationToken)
        {
            empresaDTO.AsignarFechaYHora();
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepositorio.AddAsync(empresa, cancellationToken);
        }
        public async Task ActualizarEmpresaAsync(int idempresa, CreateOrUpdateEmpresaDTO empresaDTO, CancellationToken cancellationToken)
        {
            var empresaModify = await _empresaRepositorio.GetByIdAsync(idempresa, cancellationToken).ConfigureAwait(false);
            if (empresaModify is not null)
            {
                var empresaOriginal = empresaModify;

                _mapper.Map(empresaDTO, empresaModify);

                empresaModify.Fecha = empresaOriginal.Fecha;
                empresaModify.Idempresa = empresaOriginal.Idempresa;
                empresaModify.Hora = empresaOriginal.Hora;

                await _empresaRepositorio.UpdateAsync(empresaModify, cancellationToken).ConfigureAwait(false);
            }
        }
        public async Task EliminarEmpresaAsync(int idempresa, CancellationToken cancellationToken)
        {
            await _empresaRepositorio.DeleteAsync(idempresa, cancellationToken);
        }
    }
}
