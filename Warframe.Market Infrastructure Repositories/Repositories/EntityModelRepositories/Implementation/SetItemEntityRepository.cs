using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation
{
    public class SetItemEntityRepository : ISetItemEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public SetItemEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref SetItem entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<SetItem>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(SetItem), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<SetItem>().Any(e => e.ID == entityID);
        }

        public SetItem Get(int entityID)
        {
            return DbContext.Set<SetItem>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(SetItem), entityID);
        }

        public IQueryable<SetItem> Get(Expression<Func<SetItem, bool>> predicate)
        {
            return DbContext.Set<SetItem>().Where(predicate);
        }

        public IQueryable<SetItem> GetAll()
        {
            return DbContext.Set<SetItem>();
        }

        public void Update(ref SetItem entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
