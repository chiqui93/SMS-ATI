using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class ContactosGrupoRelacion
{
    /// <summary>
    /// tabla para la relacion de muchos a muchos
    /// </summary>
    public int IdContactoGrupo{ get; set; }

    public int IdGrupoContacto { get; set; }

    public int Idcontacto { get; set; }

    public virtual GrupoContactos IdgrupoContactoNavigation { get; set; } = null!;

    public virtual Contacto IdcontactoNavigation { get; set; } = null!;
}
