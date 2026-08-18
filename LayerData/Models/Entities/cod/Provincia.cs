using System;
using System.Collections.Generic;

namespace ATIEnvioSMS.LayerData.Models.Entities.cod;

public partial class Provincia
{
    public int Idprovincia { get; set; }

    public string Provincia1 { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = [];
}
