using ATIEnvioSMS.LayerData.Models.Entities.cod;

namespace ATIEnvioSMS.LayerData.Models.DTOs.cod
{
    public class ProvinciaDTO
    {
        public int Idprovincia { get; set; }

        public string Provincia1 { get; set; } = null!;

        public IEnumerable<Empresa> ListaEmpresas { get; set; } = [];
    }
}
