using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sys
{
    public class AuditoriumRepository : BaseFullRepository<Auditorium>, IAuditoriumRepository
    {
        private readonly SistemaDbContext _context;
        public AuditoriumRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Auditorium>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Auditoria
                                 .AsNoTracking()
                                 .Select(audit => new Auditorium
                                 {
                                     Idlog = audit.Idlog,
                                     DireccionIp = audit.DireccionIp,
                                     Idusuario = audit.Idusuario,
                                     Fecha = audit.Fecha,
                                     Hora = audit.Hora                                     
                                 }).ToListAsync(cancellationToken);
        }
        public override async Task<Auditorium?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Auditoria
                                 .AsNoTracking()                                 
                                 .Select(audit => new Auditorium
                                 {
                                     Idlog = audit.Idlog,
                                     Idusuario = audit.Idusuario,
                                     Fecha = audit.Fecha,
                                     Hora = audit.Hora,
                                     Descripcion = audit.Descripcion,
                                     DireccionIp = audit.DireccionIp,
                                 }).FirstOrDefaultAsync(a => a.Idlog == id, cancellationToken);
        }
    }
}
