using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class RegSmsDetallesContactosGrupo
{
    //grupos de contactos destinatarios de un sms
    public int IdsmsDetalleContactoGrupo { get; set; }

    public int Idsms { get; set; }

    public int IdcontactoGrupo { get; set; }

    public virtual GrupoContactos IdcontactoGrupoNavigation { get; set; } = null!;

    public virtual RegSms IdsmsNavigation { get; set; } = null!;
}
