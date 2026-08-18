using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;

namespace ATIEnvioSMS.LayerData.Models.Entities.sys;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int Idempresa { get; set; }

    public bool Isadmin { get; set; }

    public bool IssuperAdmin { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public int SmsAsignados { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int IdusuarioAgrega { get; set; }

    public DateOnly FechaAct { get; set; }

    public int IdusuarioAct { get; set; }
    
    public virtual ICollection<GrupoContactos> GruposContactos { get; set; } = [];

    public virtual Empresa IdempresaNavigation { get; set; } = null!;

    public virtual ICollection<RegSms> RegSms { get; set; } = [];

    public virtual Usuario IdusuarioActNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioAgregaNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> InverseIdusuarioActNavigation { get; set; } = [];
    public virtual ICollection<Usuario> InverseIdusuarioAgregaNavigation { get; set; } = [];
    public virtual ICollection<Contacto> ContactoIdusuarioActNavigations { get; set; } = [];
    public virtual ICollection<Contacto> ContactoIdusuarioAgregaNavigations { get; set; } = [];
    
}
