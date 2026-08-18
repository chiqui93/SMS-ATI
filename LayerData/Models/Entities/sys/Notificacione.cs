using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sys;

public partial class Notificacione
{
    public int Idnotificacion { get; set; }

    public string? Notificacion { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int Destinatario { get; set; }

    public int Remitente { get; set; }

    public string Estado { get; set; } = null!;
}
