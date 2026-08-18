using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sms
{
    public class ContactoRepository : BaseFullRepository<Contacto>, IContactoRepository
    {
        private readonly SistemaDbContext _context;
        public ContactoRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Contacto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Contactos
                                 .AsNoTracking()
                                 .Include(c => c.IdempresaNavigation)
                                 .Include(c => c.IdusuarioAgregaNavigation)
                                 .Include(c => c.IdusuarioActNavigation)
                                 .Include(c => c.ContactosGrupoRelacions)
                                   .ThenInclude(gc => gc.IdcontactoNavigation)
                                 .Select(c => new Contacto
                                 {
                                     Idcontacto = c.Idcontacto,
                                     NombreTrabajador = c.NombreTrabajador,
                                     Cargo = c.Cargo,
                                     LineaCorporativa = c.LineaCorporativa,
                                     Idempresa = c.Idempresa,
                                     IdempresaNavigation = new Empresa { Nombre = c.IdempresaNavigation.Nombre },
                                     Fecha = c.Fecha,
                                     IdusuarioAgrega = c.IdusuarioAgrega,
                                     IdusuarioAgregaNavigation = new Usuario { Nombre = c.IdusuarioAgregaNavigation.Nombre },
                                     FechaAct = c.FechaAct,
                                     IdusuarioAct = c.IdusuarioAct,
                                     IdusuarioActNavigation = new Usuario { Nombre = c.IdusuarioActNavigation.Nombre },
                                     ContactosGrupoRelacions = c.ContactosGrupoRelacions.Select(gc => new ContactosGrupoRelacion
                                     {
                                         IdContactoGrupo = gc.IdContactoGrupo,
                                         IdGrupoContacto = gc.IdGrupoContacto,
                                         IdgrupoContactoNavigation = new GrupoContactos
                                         {
                                             GrupoContacto = gc.IdgrupoContactoNavigation.GrupoContacto
                                         }
                                     }).ToList()
                                 })
                                 .ToListAsync(cancellationToken);
        }

        public override async Task<Contacto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Contactos
                                .AsNoTracking()
                                .Include(c => c.IdempresaNavigation)
                                .Include(c => c.IdusuarioAgregaNavigation)
                                .Include(c => c.IdusuarioActNavigation)
                                .Include(c => c.ContactosGrupoRelacions)
                                  .ThenInclude(gc => gc.IdgrupoContactoNavigation)
                                .Select(c => new Contacto
                                {
                                    Idcontacto = c.Idcontacto,
                                    NombreTrabajador = c.NombreTrabajador,
                                    Cargo = c.Cargo,
                                    LineaCorporativa = c.LineaCorporativa,
                                    Idempresa = c.Idempresa,
                                    IdempresaNavigation = new Empresa { Nombre = c.IdempresaNavigation.Nombre },
                                    Fecha = c.Fecha,
                                    IdusuarioAgrega = c.IdusuarioAgrega,
                                    IdusuarioAgregaNavigation = new Usuario { Nombre = c.IdusuarioAgregaNavigation.Nombre },
                                    FechaAct = c.FechaAct,
                                    IdusuarioAct = c.IdusuarioAct,
                                    IdusuarioActNavigation = new Usuario { Nombre = c.IdusuarioActNavigation.Nombre },
                                    ContactosGrupoRelacions = c.ContactosGrupoRelacions.Select(gc => new ContactosGrupoRelacion
                                    {
                                        IdContactoGrupo = gc.IdContactoGrupo,
                                        IdGrupoContacto = gc.IdGrupoContacto,
                                        IdgrupoContactoNavigation = new GrupoContactos
                                        {
                                            GrupoContacto = gc.IdgrupoContactoNavigation.GrupoContacto
                                        }
                                    }).ToList()
                                })
                                .FirstOrDefaultAsync(c => c.Idcontacto == id, cancellationToken);
        }
    }
}
