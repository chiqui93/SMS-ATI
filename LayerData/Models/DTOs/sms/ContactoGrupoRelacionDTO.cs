
namespace ATIEnvioSMS.LayerData.Models.DTOs.sms
{
    public class BaseContactoGrupoRelacionDTO
    {
        public List<ContactoParaGruposDTO> Contactos { get; set; } = [];    
    }

    public class CreateContactoGrupoRelacionDTO
    {
        public int IdGrupoContacto { get; set; }
        public List<int> ListaContactos { get; set; } = [];
    }

    public class UpdateContactoGrupoRelacionDTO: CreateContactoGrupoRelacionDTO
    {
        public int IdContactoGrupo { get; set; }
    }
}
