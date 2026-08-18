using ATIEnvioSMS.LayerData.Models.Entities.sys;
using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class RegSms
{
    public int Idsms { get; set; }

    public string Sms { get; set; } = null!;

    /// <summary>
    /// usuario que envia el sms
    /// </summary>
    public int Idusuario { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public bool Pendiente { get; set; }

    public bool Enviado { get; set; }

    public DateOnly? FechaConfirmacion { get; set; }

    public TimeOnly? HoraConfirmacion { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;

    public virtual ICollection<RegSmsDetallesContacto> RegSmsDetallesContactos { get; set; } = new List<RegSmsDetallesContacto>();

    public virtual ICollection<RegSmsDetallesContactosGrupo> RegSmsDetallesContactosGrupos { get; set; } = new List<RegSmsDetallesContactosGrupo>();
}
