using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Abstractions;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions
{
    public abstract class AClassDomainModelRepository<TEntity, TDomain, TContext> : IClassDomainModelRepository<TEntity, TDomain>
        where TEntity : AEntityModel
        where TDomain : ADomainModel
        where TContext : DbContext
    {

        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<TContext>();
        public AClassDomainModelRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public virtual void Create(ref TDomain entity)
        {
            var mappedEntityObject = DomainModelMapper.Map<TDomain, TEntity>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<TEntity>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            DomainModelMapper.Map(mappedEntityObject, entity);
        }

        public virtual void Delete(int entityID)
        {
            var entity = DbContext.Set<TEntity>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(typeof(TEntity).FullName, entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public virtual bool Exists(int entityID)
        {
            return DbContext.Set<TEntity>()
                .Any(predicate => predicate.ID == entityID);
        }

        public virtual TDomain Get(int entityID)
        {
            var foundEntity = DbContext.Set<TEntity>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(typeof(TEntity).FullName, entityID);

            return DomainModelMapper.Map<TDomain>(foundEntity);
        }

        public virtual IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> predicate)
        {
            var mappedPredicate = DomainModelMapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            return DbContext.Set<TEntity>()
                .Where(mappedPredicate)
                .Select(entity => DomainModelMapper.Map<TDomain>(entity));
        }

        public virtual IEnumerable<TDomain> GetAll()
        {
            return DbContext.Set<TEntity>()
                .Select(entity => DomainModelMapper.Map<TDomain>(entity));
        }

        public virtual void Update(ref TDomain entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<TEntity>()
                .SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(typeof(TEntity).FullName, entity.ID);

            DomainModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            DomainModelMapper.Map(searchedEntity, entity);
        }
    }
}
