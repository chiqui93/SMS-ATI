using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sys
{
    public class NotificacionesRepository : BaseFullRepository<Notificacione>, INotificacionesRepository
    {
        private readonly SistemaDbContext _context;
        public NotificacionesRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Notificacione>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Notificaciones
                                 .AsNoTracking()
                                 .Select(notif => new Notificacione
                                 {
                                     Idnotificacion = notif.Idnotificacion,
                                     Fecha = notif.Fecha,
                                     Hora = notif.Hora,
                                     Estado = notif.Estado,
                                     Destinatario = notif.Destinatario,
                                 }).ToListAsync(cancellationToken);
        }

        public override async Task<Notificacione?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Notificaciones
                                 .AsNoTracking()
                                 .Select(notif => new Notificacione
                                 {
                                     Idnotificacion = notif.Idnotificacion,
                                     Fecha = notif.Fecha,
                                     Hora = notif.Hora,
                                     Estado = notif.Estado,
                                     Destinatario = notif.Destinatario,
                                     Notificacion = notif.Notificacion,
                                     Remitente = notif.Remitente
                                 }).FirstOrDefaultAsync(n => n.Idnotificacion == id, cancellationToken);

        }
    }
}
