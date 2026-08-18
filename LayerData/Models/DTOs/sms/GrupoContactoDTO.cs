namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public abstract class BaseGrupoContactoDTO
    {
        public string GrupoContacto { get; set; } = null!;
        /// <summary>
        /// si se encuentra lleno entonces el grupo es personalizado(solo lo vera ese usuario)
        /// </summary>
        public int? Idusuario { get; set; }
        /// <summary>
        /// para verificar si es visible para todos los usuarios de la empresa
        /// </summary>
        public bool General { get; set; }
        /// <summary>
        /// para verificar si es visible para todos los usuarios de todas las empresas
        /// </summary>
        public bool Global { get; set; }

        public DateOnly Fecha { get; private set; }
        public DateOnly FechaAct { get; private set; }
        public int IdusuarioAct { get; set; }
        /// <summary>
        /// entidad del grupo de contactos general(entidad donde se va a ver el grupo)
        /// </summary>
        public int? Idempresa { get; set; }
        public bool Activo { get; set; }

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
    public class GrupoContactoDTO : BaseGrupoContactoDTO
    {
        public int IdGrupoContacto { get; set; }
        public string? UsuarioPertenece { get; set; }      
        public string? UsuarioAct { get; set; }
        public int IdusuarioAgrega { get; set; }
        public string? UsuarioAgrega { get; set; }
        public string? Empresa { get; set; }
    }

    public class GrupoContactoConContactosDTO : GrupoContactoDTO 
    {
        public virtual IEnumerable<BaseContactoGrupoRelacionDTO> ListaContactos { get; set; } = [];
    }

    public class CreateGrupoContactosDTO : BaseGrupoContactoDTO
    {
        public int IdusuarioAgrega { get; set; }
    }

    public class UpdateGrupoContactosDTO : BaseGrupoContactoDTO
    {
    }
}





