using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Repository.Interfaces.sms;

namespace ATIEnvioSMS.LayerData.Repository.Implementations.sms
{
    public class ContactGrupoRelacionRepository : BaseFullRepository<ContactosGrupoRelacion>, IContactGrupoRelacionRepository
    {
        private readonly SistemaDbContext _context;
        public ContactGrupoRelacionRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
