namespace ATIEnvioSMS.LayerData.Repository.Interfaces
{
    public interface IBaseReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }

    public interface IBaseFullRepository<TEntity> : IBaseReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
