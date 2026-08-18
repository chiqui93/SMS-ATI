namespace ATIEnvioSMS.LayerData.Models.DTOs.sys
{
    public class BaseAuditoriumDTO
    {
        
        public DateOnly Fecha { get; private set; }

        public void AsignarFecha()
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now);            
        }

        public TimeOnly Hora { get; set; }
        
        public string DireccionIp { get; set; } = null!;
    }

    public class AuditoriumDTO : BaseAuditoriumDTO
    {
        public int Idlog { get; set; }

        public string Descripcion { get; set; } = null!;

        public int Idusuario { get; set; }
    }

    public class CreateAuditoriumDTO: BaseAuditoriumDTO
    {
        public int Idlog { get; set; }

        public string Descripcion { get; set; } = null!;

        public int Idusuario { get; set; }
    }
}
