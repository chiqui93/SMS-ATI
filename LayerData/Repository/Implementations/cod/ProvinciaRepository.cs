using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.cod;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.cod
{
    public class ProvinciaRepository : BaseFullRepository<Provincia>, IProvinciaRepository
    {
        private readonly SistemaDbContext _context;
        public ProvinciaRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Provincia>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Provincias
                                 .AsNoTracking()                             
                                 .Select(prov => new Provincia
                                 {
                                     Idprovincia = prov.Idprovincia,
                                     Provincia1 = prov.Provincia1,                                    
                                 }).ToListAsync(cancellationToken);
        }

        public override async Task<Provincia?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Provincias
                                 .AsNoTracking()
                                 .Include(prov => prov.Empresas)
                                 .Select(prov => new Provincia
                                 {
                                     Idprovincia = prov.Idprovincia,
                                     Provincia1 = prov.Provincia1,
                                     Empresas = prov.Empresas.Select(e => new Empresa
                                     {
                                         Idempresa = e.Idempresa,
                                         Nombre = e.Nombre,
                                         Activa = e.Activa,
                                         Fecha = e.Fecha,
                                         Hora = e.Hora,
                                     }).ToList()
                                 }).FirstOrDefaultAsync(e => e.Idprovincia == id, cancellationToken);
        }
    }
}
