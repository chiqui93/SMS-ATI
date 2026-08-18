
namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public abstract class BaseRegSmsDetallesContactosGrupoDTO
    {        
        public int IdcontactoGrupo { get; set; }        
    }
    public class RegSmsDetallesContactosGrupoDTO: BaseRegSmsDetallesContactosGrupoDTO
    {
        public int IdsmsDetalleContactoGrupo { get; set; }
        public string? ContactoGrupo { get; set; }
    }
    public class CreateRegSmsDetallesContactosGrupoDTO: BaseRegSmsDetallesContactosGrupoDTO
    {
        public int Idsms { get; set; }
    }
}
