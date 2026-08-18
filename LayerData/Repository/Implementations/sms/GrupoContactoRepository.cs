using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sms
{
    public class GrupoContactoRepository : BaseFullRepository<GrupoContactos>, IGrupoContactoRepository
    {
        private readonly SistemaDbContext _context;
        public GrupoContactoRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<GrupoContactos>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.GrupoContactos
                                .AsNoTracking()
                                .Include(gc=>gc.IdusuarioNavigation)
                                .Select(c => new GrupoContactos
                                {
                                    IdGrupoContacto = c.IdGrupoContacto,
                                    GrupoContacto = c.GrupoContacto,
                                    Activo = c.Activo,
                                    Idempresa = c.Idempresa,
                                    Fecha = c.Fecha,
                                    IdusuarioAgrega = c.IdusuarioAgrega,
                                    FechaAct = c.FechaAct,
                                    IdusuarioAct = c.IdusuarioAct,
                                    General = c.General,
                                    Global = c.Global,
                                    Idusuario = c.Idusuario,
                                    IdusuarioNavigation = new Usuario { Nombre = c.IdusuarioNavigation.Nombre },
                                })
                                .ToListAsync(cancellationToken);
        }

        public override async Task<GrupoContactos?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.GrupoContactos
                                .AsNoTracking()
                                .Include(gc => gc.IdusuarioNavigation)
                                .Include(gc => gc.ContactosGrupoRelacions)
                                   .ThenInclude(r => r.IdcontactoNavigation)
                                   .ThenInclude(c => c.IdempresaNavigation)
                                .Select(c => new GrupoContactos
                                {
                                    IdGrupoContacto = c.IdGrupoContacto,
                                    GrupoContacto = c.GrupoContacto,
                                    Activo = c.Activo,
                                    Idempresa = c.Idempresa,
                                    Fecha = c.Fecha,
                                    IdusuarioAgrega = c.IdusuarioAgrega,
                                    FechaAct = c.FechaAct,
                                    IdusuarioAct = c.IdusuarioAct,
                                    General = c.General,
                                    Global = c.Global,
                                    Idusuario = c.Idusuario,
                                    IdusuarioNavigation = new Usuario { Nombre = c.IdusuarioNavigation.Nombre },
                                    ContactosGrupoRelacions = c.ContactosGrupoRelacions.Select(r => new ContactosGrupoRelacion
                                    {
                                        IdContactoGrupo = r.IdContactoGrupo,
                                        IdcontactoNavigation = new Contacto
                                        {
                                            Idcontacto = r.IdcontactoNavigation.Idcontacto,
                                            IdempresaNavigation = new Empresa
                                            {
                                                Idempresa = r.IdcontactoNavigation.Idempresa,
                                                Nombre = r.IdcontactoNavigation.IdempresaNavigation.Nombre
                                            },
                                            LineaCorporativa = r.IdcontactoNavigation.LineaCorporativa,
                                            NombreTrabajador = r.IdcontactoNavigation.NombreTrabajador,
                                            Cargo = r.IdcontactoNavigation.Cargo,
                                        }
                                    }).ToList()
                                })
                                .FirstOrDefaultAsync(gc => gc.IdGrupoContacto == id, cancellationToken);
        }
    }
}
