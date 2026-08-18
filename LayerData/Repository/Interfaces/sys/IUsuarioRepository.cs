using ATIEnvioSMS.LayerData.Models.Entities.sys;

namespace ATIEnvioSMS.LayerData.Repository.Interfaces.sys
{
    public interface IUsuarioRepository : IBaseFullRepository<Usuario>
    {
        Task<Usuario?> VerifyUserAsync(string user, string password, CancellationToken cancellationToken);
    }
}
