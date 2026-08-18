using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.sys;

public partial class Auditorium
{
    public int Idlog { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Idusuario { get; set; }

    public string DireccionIp { get; set; } = null!;
}
