using ATIEnvioSMS.LayerData.Models.Entities.sys;

namespace ATIEnvioSMS.LayerData.Models.Entities.sms;

public partial class GrupoContactos
{
    public int IdGrupoContacto { get; set; }

    public string GrupoContacto { get; set; } = null!;

    public int? Idusuario { get; set; }

    public int IdusuarioAgrega { get; set; }
    public DateOnly Fecha { get; set; }

    /// <summary>
    /// para verificar si es visible para todos los usuarios de la empresa
    /// </summary>
    public bool General { get; set; }

    /// <summary>
    /// para verificar si es visible para todos los usuarios de todas las empresas
    /// </summary>
    public bool Global { get; set; }

    public DateOnly FechaAct { get; set; }

    public int IdusuarioAct { get; set; }

    /// <summary>
    /// entidad del grupo de contactos general(entidad donde se va a ver el grupo)
    /// </summary>
    public int? Idempresa { get; set; }

    public bool Activo { get; set; }
        
    public virtual ICollection<ContactosGrupoRelacion> ContactosGrupoRelacions { get; set; } = [];

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<RegSmsDetallesContactosGrupo> RegSmsDetallesContactosGrupos { get; set; } = [];
}
