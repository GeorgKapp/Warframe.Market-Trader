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
    public class ItemTagEntityRepository : IItemTagEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public ItemTagEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref ItemTag entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<ItemTag>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(ItemTag), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<ItemTag>().Any(e => e.ID == entityID);
        }

        public ItemTag Get(int entityID)
        {
            return DbContext.Set<ItemTag>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(ItemTag), entityID);
        }

        public IQueryable<ItemTag> Get(Expression<Func<ItemTag, bool>> predicate)
        {
            return DbContext.Set<ItemTag>().Where(predicate);
        }

        public IQueryable<ItemTag> GetAll()
        {
            return DbContext.Set<ItemTag>();
        }

        public void Update(ref ItemTag entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
