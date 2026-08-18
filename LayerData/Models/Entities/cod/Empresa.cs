using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;

namespace ATIEnvioSMS.LayerData.Models.Entities.cod;

public partial class Empresa
{
    public int Idempresa { get; set; }
       
    /// fecha y hora de creado el registro
    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activa { get; set; }

    public int? Idprovincia { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = [];

    public virtual Provincia? IdprovinciaNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = [];
}
