using ATIEnvioSMS.LayerData.Data;
using ATIEnvioSMS.LayerData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Repository.Implementations
{
    public class BaseFullRepository<TEntity> : BaseReadOnlyRepository<TEntity>, IBaseFullRepository<TEntity> where TEntity : class
    {
        private readonly SistemaDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseFullRepository(SistemaDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                await _dbSet.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            bool actualizado = false;
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
                actualizado = true;
            }

            catch (Exception)
            {

                return actualizado;
            }

            return actualizado;
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            bool eliminado = false;
            var entidad = await _dbSet.FindAsync(id, cancellationToken);
            if (entidad is not null)
            {
                try
                {
                    _context.Entry(entidad).State = EntityState.Deleted;
                    await _context.SaveChangesAsync(cancellationToken);
                    eliminado = true;
                }
                catch (Exception)
                {
                    return eliminado;
                }
            }
            return eliminado;
        }
    }
}
