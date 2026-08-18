
namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public class BaseContactoDTO
    {
        public string LineaCorporativa { get; set; } = null!;
        public int Idempresa { get; set; }
        public string NombreTrabajador { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public DateOnly FechaAct { get; private set; }
        public DateOnly Fecha { get; private set; }
        public int IdusuarioAct { get; set; }
        public void AsignarFecha()
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now);
            FechaAct = DateOnly.FromDateTime(DateTime.Now);
        }
        public void AsignarFechaAct()
        {
            FechaAct = DateOnly.FromDateTime(DateTime.Now);
        }
    }
    public class ContactoDTO: BaseContactoDTO
    {
       // public DateOnly Fecha { get; set; }
        public int Idcontacto { get; set; }
        public string? Empresa { get; set; }
        public int IdusuarioAgrega { get; set; }
        public string? UsuarioAgrega { get; set; }
        public string? UsuarioAct { get; set; }
    }

    public class ContactoSMSDetalleDTO {
        public string LineaCorporativa { get; set; } = null!;
        public int Idempresa { get; set; }
        public string? Empresa { get; set; }
        public string NombreTrabajador { get; set; } = null!;
        public string Cargo { get; set; } = null!;
    }

    public class CreateContactoDTO : BaseContactoDTO
    {
        public int IdusuarioAgrega { get; set; }
    }

    public class UpdateContactoDTO: BaseContactoDTO
    {
    }

    public class ContactoSinEmpresaDTO {
        public int IdContacto { get; set; }
        public string LineaCorporativa { get; set; } = null!;
        public string NombreTrabajador { get; set; } = null!;
        public string Cargo { get; set; } = null!;
    }

    public class ContactoParaGruposDTO : ContactoSinEmpresaDTO {
        public int IdEmpresa { get; set; }
        public string Empresa { get; set; } = null!;
    }
}
