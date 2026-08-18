using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sys;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sys
{
    public class UsuarioRepository : BaseFullRepository<Usuario>, IUsuarioRepository
    {
        private readonly SistemaDbContext _context;

        public UsuarioRepository(SistemaDbContext context): base(context) 
        {
            _context = context;
        }

        public override async Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                                 .AsNoTracking()
                                 .Include(u => u.IdempresaNavigation)
                                 .Include(u => u.IdusuarioAgregaNavigation)
                                 .Include(u => u.IdusuarioActNavigation)
                                 .Include(u => u.GruposContactos)
                                         .Select(u => new Usuario
                                         {
                                             Idusuario = u.Idusuario,
                                             Nombre = u.Nombre,
                                             Apellidos = u.Apellidos,
                                             Usuario1 = u.Usuario1,
                                             IssuperAdmin = u.IssuperAdmin,
                                             Isadmin = u.Isadmin,
                                             Idempresa = u.Idempresa,
                                             IdempresaNavigation = new Empresa { Nombre = u.IdempresaNavigation.Nombre },
                                             Fecha = u.Fecha,
                                             FechaAct = u.FechaAct,
                                             SmsAsignados = u.SmsAsignados,
                                             Email = u.Email,                                             
                                             IdusuarioAgrega = u.IdusuarioAgrega,
                                             IdusuarioAgregaNavigation = new Usuario { Nombre = u.IdusuarioAgregaNavigation.Nombre },
                                             IdusuarioAct = u.IdusuarioAct,
                                             IdusuarioActNavigation = new Usuario { Nombre = u.IdusuarioActNavigation.Nombre },
                                         }).ToListAsync(cancellationToken);

        }
        public override async Task<Usuario?> GetByIdAsync(int idUsuario, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                              .AsNoTracking()
                              .Include(u => u.IdempresaNavigation).AsNoTracking()
                              .Include(u => u.IdusuarioAgregaNavigation).AsNoTracking()
                              .Include(u => u.IdusuarioActNavigation).AsNoTracking()
                              .Include(u => u.GruposContactos).AsNoTracking()
                               .Select(u => new Usuario
                               {
                                   Idusuario = u.Idusuario,
                                   Nombre = u.Nombre,
                                   Apellidos = u.Apellidos,
                                   Usuario1 = u.Usuario1,
                                   IssuperAdmin = u.IssuperAdmin,
                                   Isadmin = u.Isadmin,
                                   Idempresa = u.Idempresa,
                                   IdempresaNavigation = new Empresa { Nombre = u.IdempresaNavigation.Nombre },
                                   Fecha = u.Fecha,
                                   Email = u.Email,
                                   Foto = u.Foto,
                                   SmsAsignados = u.SmsAsignados,
                                   IdusuarioAgrega = u.IdusuarioAgrega,
                                   IdusuarioAgregaNavigation = new Usuario { Nombre = u.IdusuarioAgregaNavigation.Nombre },
                                   IdusuarioAct = u.IdusuarioAct,
                                   IdusuarioActNavigation = new Usuario { Nombre = u.IdusuarioActNavigation.Nombre },
                                   FechaAct = u.FechaAct,
                                   GruposContactos = u.GruposContactos.Select(cg => new GrupoContactos
                                   {
                                       IdGrupoContacto = cg.IdGrupoContacto,
                                       GrupoContacto = cg.GrupoContacto
                                   }).ToList(),
                                   RegSms = u.RegSms,
                               })
                              .FirstOrDefaultAsync(u => u.Idusuario == idUsuario, cancellationToken);
        }

        public async Task<Usuario?> VerifyUserAsync(string user, string password, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Usuario1 == user && u.Clave.Equals(password), cancellationToken);
        }
    }
}
