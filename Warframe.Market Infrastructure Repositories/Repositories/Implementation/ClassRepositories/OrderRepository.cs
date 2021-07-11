using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public OrderRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.Order entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Order, Order>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<Order>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<Order>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(Order), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Market_DomainModels.Models.Order Get(int entityID)
        {
            var searchedEntity =
                DbContext.Set<Order>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(Order), entityID);

            return ModelMapper.Map<Market_DomainModels.Models.Order>(searchedEntity);
        }

        public IEnumerable<Market_DomainModels.Models.Order> Get(Expression<Func<Market_DomainModels.Models.Order, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Order, bool>>>(predicate);

            return DbContext.Set<Order>().Where(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Order> GetAll()
        {
            return DbContext.Set<Order>()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Order entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<Order>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(Order), entity.ID);

            ModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            ModelMapper.Map(searchedEntity, entity);
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<Order>().Any(e => e.ID == entityID);
        }
    }
}
