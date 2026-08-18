using ATIEnvioSMS.LayerData.Models.DTOs.sms;

namespace ATIEnvioSMS.LayerData.Models.DTOs.sys
{
    public class BaseUsuarioDTO
    {
        public string NombUsuario { get; set; } = null!;
                               
        public bool Isadmin { get; set; }

        public bool IssuperAdmin { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public byte[]? Foto { get; set; }

        public int SmsAsignados { get; set; }

        public string Email { get; set; } = null!;
        public int Idempresa { get; set; }
        public DateOnly Fecha { get; private set; }
        public void AsignarFecha()
        { 
            Fecha = DateOnly.FromDateTime(DateTime.Now);
            AsignarFechaAct();
        }

        public void AsignarFecha(DateOnly pFecha) => Fecha = pFecha;
        public int IdusuarioAgrega { get; set; }
        public int IdusuarioAct { get; set; }
        public DateOnly FechaAct { get; private set; }
        public void AsignarFechaAct() => FechaAct = DateOnly.FromDateTime(DateTime.Now);

    }
    public class UsuarioDTO : BaseUsuarioDTO
    {
        public int Idusuario { get; set; }
        public string? Empresa { get; set; }
        public virtual IEnumerable<GrupoContactoDTO> ListaGruposDeContactos { get; set; } = [];
        public string? UsuarioAgrega { get; set; }
        public string? UsuarioAct { get; set; }
    }

    public class CreateUsuarioDTO : BaseUsuarioDTO
    {
        public string Clave { get; set; } = null!;
    }

    public class UpdateUsuarioDTO : BaseUsuarioDTO
    {
        public int Idusuario { get; set; }
        public string Clave { get; set; } = null!;
    }

}
