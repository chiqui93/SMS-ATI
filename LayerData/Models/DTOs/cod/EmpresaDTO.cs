
using ATIEnvioSMS.LayerData.Models.DTOs.sms;

namespace ATIEnvioSMS.LayerData.Models.DTOs.cod
{
    public class BaseEmpresaDTO
    {

        /// fecha y hora de creado el registro
        public DateOnly Fecha { get; private set; }

        public TimeOnly Hora { get; private set; }

        public string Nombre { get; set; } = null!;

        public int CantSms { get; set; }

        public bool Activa { get; set; }

        public void AsignarFechaYHora()
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now);
            Hora = TimeOnly.FromDateTime(DateTime.Now);
        }
    }
    public class EmpresaDTO : BaseEmpresaDTO
    {
        public int Idempresa { get; set; }
        public IEnumerable<ContactoSinEmpresaDTO> ListaContactos { get; set; } = [];

    }

    public class CreateOrUpdateEmpresaDTO : BaseEmpresaDTO
    {
    }
}
