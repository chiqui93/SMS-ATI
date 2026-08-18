using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Implementations.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sys;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.sys
{
    public class AuditoriumUseCaseServices : IAuditoriumUseCases
    {
        private readonly IAuditoriumRepository _logRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuditoriumUseCaseServices(IAuditoriumRepository logRepository, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<AuditoriumDTO>> ObtenerTodosLosLogAsync(CancellationToken cancellationToken)
        {
            var audit = await _logRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<AuditoriumDTO>>(audit);
           /* foreach (var log in auditDtos) {
                var usuarioData = await _usuarioRepository.GetByIdAsync(audit.Idusuario, cancellationToken).ConfigureAwait(false);
                log.Usuario = usuarioData?.Usuario1;
            }*/
           
        }

        public async Task AgregarLogAsync(CreateAuditoriumDTO logDTO, CancellationToken cancellationToken)
        {
            var logNuevo = _mapper.Map<Auditorium>(logDTO);
            logNuevo.Fecha = DateOnly.FromDateTime(DateTime.Now);
            logNuevo.Hora = TimeOnly.FromDateTime(DateTime.Now);

            await _logRepository.AddAsync(logNuevo, cancellationToken).ConfigureAwait(false);
        }

    }
}
