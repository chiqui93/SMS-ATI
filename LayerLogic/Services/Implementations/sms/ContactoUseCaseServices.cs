using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using ATIEnvioSMS.LayerLogic.Services.Interfaces.sms;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Services.Implementations.sms
{
    public class ContactoUseCaseServices : IContactoUseCases
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly IMapper _mapper;

        public ContactoUseCaseServices(IContactoRepository contactoRepository, IMapper mapper)
        {
            _contactoRepository = contactoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ContactoDTO>> ObtenerTodosContactosAsync(CancellationToken cancellationToken)
        {
            var contactos = await _contactoRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<ContactoDTO>>(contactos);
        }

        public async Task<ContactoDTO?> ObtenerContactoByIdAsync(int idcontacto, CancellationToken cancellationToken)
        {
            var contacto = await _contactoRepository.GetByIdAsync(idcontacto, cancellationToken).ConfigureAwait(false);
            if (contacto == null)
                return null;
            return _mapper.Map<ContactoDTO>(contacto);
        }

        public async Task AgregarContactoAsync(CreateContactoDTO contactoDTO, CancellationToken cancellationToken)
        {
            contactoDTO.AsignarFecha();
            var contactoNuevo = _mapper.Map<Contacto>(contactoDTO);
            await _contactoRepository.AddAsync(contactoNuevo, cancellationToken).ConfigureAwait(false);
        }

        public async Task ActualizarContactoAsync(int idcontacto, UpdateContactoDTO contactoDTO, CancellationToken cancellationToken)
        {
            var contactoModify = await _contactoRepository.GetByIdAsync(idcontacto, cancellationToken).ConfigureAwait(false);
            if (contactoModify is not null)
            {
                contactoDTO.AsignarFechaAct();
                var contactoOriginal = contactoModify;
                _mapper.Map(contactoDTO, contactoModify);
                contactoModify.Fecha = contactoOriginal.Fecha;
                contactoModify.Idcontacto = contactoOriginal.Idcontacto;
                contactoModify.IdusuarioAgrega = contactoOriginal.IdusuarioAgrega;
                await _contactoRepository.UpdateAsync(contactoModify, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task EliminarContactoAsync(int idcontacto, CancellationToken cancellationToken)
        {
            await _contactoRepository.DeleteAsync(idcontacto, cancellationToken);
        }
    }
}
