
namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public abstract class BaseRegSmsDTO
    {
        public string Sms { get; set; } = null!;
        /// <summary>
        /// usuario que envia el sms
        /// </summary>
        public int Idusuario { get; set; }
        public DateOnly Fecha { get; private set; }
        public TimeOnly Hora { get; private set; }
        public bool Pendiente { get; private set; }
        public bool Enviado { get; private set; }
        public DateOnly? FechaConfirmacion { get; private set; }
        public TimeOnly? HoraConfirmacion { get; private set; }

        public void AsignarFechaYHoraEnvio()
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now);
            Hora = TimeOnly.FromDateTime(DateTime.Now);
            Pendiente = true;
        }

        public void ConfirmarEnvio()
        {
            Pendiente = false;
            Enviado = true;
            FechaConfirmacion = DateOnly.FromDateTime(DateTime.Now);
            HoraConfirmacion = TimeOnly.FromDateTime(DateTime.Now);
        }
    }
    public class RegSmsDTO : BaseRegSmsDTO
    {
        public int Idsms { get; set; }
        public string Usuario { get; set; } = null!;
        public IEnumerable<RegSmsDetallesContactoDTO> ListaContactosEnviados { get; set; } = [];
        public IEnumerable<RegSmsDetallesContactosGrupoDTO> ListaGruposContactosEnviados { get; set; } = [];
    }
    public class CreateSmsDTO : BaseRegSmsDTO
    {
        public IEnumerable<CreateRegSmsDetallesContactosGrupoDTO> ListaGruposContactosEnviados { get; set; } = [];
        public IEnumerable<CreateRegSmsDetallesContactoDTO> ListaContactosEnviados { get; set; } = [];
    }

}
