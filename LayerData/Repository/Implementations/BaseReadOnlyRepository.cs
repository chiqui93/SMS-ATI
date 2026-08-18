using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations
{
    public class BaseReadOnlyRepository<TEntity> : IBaseReadOnlyRepository<TEntity> where TEntity : class
    {
        private readonly SistemaDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseReadOnlyRepository(SistemaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
