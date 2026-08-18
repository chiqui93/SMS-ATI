using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class Contacto
{
    public int Idcontacto { get; set; }

    public string LineaCorporativa { get; set; } = null!;

    public int Idempresa { get; set; }

    public string NombreTrabajador { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int IdusuarioAgrega { get; set; }

    public DateOnly FechaAct { get; set; }

    public int IdusuarioAct { get; set; }

    public virtual ICollection<ContactosGrupoRelacion> ContactosGrupoRelacions { get; set; } = [];

    public virtual Empresa IdempresaNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioActNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioAgregaNavigation { get; set; } = null!;

    public virtual ICollection<RegSmsDetallesContacto> RegSmsDetallesContactos { get; set; } = [];
}
