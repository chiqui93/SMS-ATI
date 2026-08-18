using ATIEnvioSMS.LayerData.Models.Entities.sms;

namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public abstract class BaseRegSmsDetallesContactoDTO
    {
        public int Idcontacto { get; set; }
    }
    public class RegSmsDetallesContactoDTO : BaseRegSmsDetallesContactoDTO
    {
        public int IdsmsDetalleContacto { get; set; }
        public ContactoSMSDetalleDTO ContactoDetalle { get; set; } = new();
    }

    public class CreateRegSmsDetallesContactoDTO : BaseRegSmsDetallesContactoDTO
    {
        public int Idsms { get; set; }
    }
}
