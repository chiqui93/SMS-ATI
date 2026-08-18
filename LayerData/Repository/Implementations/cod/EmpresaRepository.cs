using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.cod;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.cod
{
    public class EmpresaRepository : BaseFullRepository<Empresa>, IEmpresaRepository
    {
        private readonly SistemaDbContext _context;
        public EmpresaRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Empresa>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Empresas
                                 .AsNoTracking()
                                 .Select(emp => new Empresa
                                 {
                                     Idempresa = emp.Idempresa,
                                     Nombre = emp.Nombre,
                                     Fecha = emp.Fecha,
                                     Hora = emp.Hora,
                                     Activa = emp.Activa,
                                     Idprovincia = emp.Idprovincia,
                                 }).ToListAsync(cancellationToken);
        }

        public override async Task<Empresa?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Empresas
                                 .AsNoTracking()
                                 .Include(emp => emp.Contactos)
                                 .Select(emp => new Empresa
                                 {
                                     Idempresa = emp.Idempresa,
                                     Nombre = emp.Nombre,
                                     Fecha = emp.Fecha,
                                     Hora = emp.Hora,
                                     Activa = emp.Activa,
                                     Idprovincia = emp.Idprovincia,
                                     Contactos = emp.Contactos.Select(c => new Contacto
                                     {
                                         Idcontacto = c.Idcontacto,
                                         LineaCorporativa = c.LineaCorporativa,
                                         NombreTrabajador = c.NombreTrabajador,
                                         Cargo = c.Cargo
                                     }).ToList()
                                 }).FirstOrDefaultAsync(e => e.Idempresa == id, cancellationToken);
        }
    }
}
