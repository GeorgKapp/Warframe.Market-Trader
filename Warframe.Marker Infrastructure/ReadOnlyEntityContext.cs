using System;
using System.Linq;

namespace Warframe.Market_Infrastructure
{
    //Todo: Create universal object context that has options for readonly etc
    public class ReadOnlyEntityContext : IDisposable
    {
        private readonly EntityContext _dbContext;
        public ReadOnlyEntityContext()
        {
            _dbContext = new EntityContext();
        }

        public IQueryable<TEntity> Set<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
