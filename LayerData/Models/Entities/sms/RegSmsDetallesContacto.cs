using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class RegSmsDetallesContacto
{
    //contactos destinatarios de un sms
    public int IdsmsDetalleContacto { get; set; }

    public int Idsms { get; set; }

    public int Idcontacto { get; set; }

    public virtual Contacto IdcontactoNavigation { get; set; } = null!;

    public virtual RegSms IdsmsNavigation { get; set; } = null!;
}
