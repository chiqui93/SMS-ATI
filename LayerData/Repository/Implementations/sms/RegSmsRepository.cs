using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sms
{
    public class RegSmsRepository : BaseFullRepository<RegSms>, IRegSmsRepository
    {
        private readonly SistemaDbContext _context;

        public RegSmsRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<RegSms>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.RegSms
                                 .AsNoTracking()
                                 .Select(sms => new RegSms
                                 {
                                     Idsms = sms.Idsms,
                                     Idusuario = sms.Idusuario,
                                     Fecha = sms.Fecha,
                                     Hora = sms.Hora,
                                     FechaConfirmacion = sms.FechaConfirmacion,
                                     HoraConfirmacion = sms.HoraConfirmacion,                                     
                                 }).ToListAsync(cancellationToken);
        }

        public override async Task<RegSms?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.RegSms
                                 .AsNoTracking()
                                 .Include(sms => sms.RegSmsDetallesContactos)
                                 .Include(sms => sms.RegSmsDetallesContactosGrupos)
                                 .Select(sms => new RegSms
                                 {
                                     Idsms = sms.Idsms,
                                     Idusuario = sms.Idusuario,
                                     Fecha = sms.Fecha,
                                     Hora = sms.Hora,
                                     FechaConfirmacion = sms.FechaConfirmacion,
                                     HoraConfirmacion = sms.HoraConfirmacion,
                                     Enviado = sms.Enviado,
                                     Pendiente = sms.Pendiente,
                                     RegSmsDetallesContactos = sms.RegSmsDetallesContactos.Select(contac => new RegSmsDetallesContacto
                                     {
                                         IdsmsDetalleContacto = contac.IdsmsDetalleContacto,
                                         Idcontacto = contac.Idcontacto,                                         
                                     }).ToList(),
                                     RegSmsDetallesContactosGrupos = sms.RegSmsDetallesContactosGrupos.Select(grupo => new RegSmsDetallesContactosGrupo
                                     {
                                         IdsmsDetalleContactoGrupo = grupo.IdsmsDetalleContactoGrupo,
                                         IdcontactoGrupo = grupo.IdcontactoGrupo                                         
                                     }).ToList()
                                 }).FirstOrDefaultAsync(cancellationToken);

                                     
        }
    }
}
