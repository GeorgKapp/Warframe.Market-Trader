using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class OrderDomainRepository : IOrderDomainRepository
    {
        private readonly IOrderEntityRepository _entityOrderRepository;
        private readonly IUserEntityRepository _entityUserRepository;

        public OrderDomainRepository(IOrderEntityRepository entityOrderRepository, IUserEntityRepository entityUserRepository)
        {
            _entityOrderRepository = entityOrderRepository ?? throw new ArgumentNullException(nameof(entityOrderRepository));
            _entityUserRepository = entityUserRepository ?? throw new ArgumentNullException(nameof(entityUserRepository));
        }

        public void Create(ref Market_DomainModels.Models.Order entity, int userId)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Order, Order>(entity);
            mappedEntityObject.User = _entityUserRepository.Get(userId);
            _entityOrderRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityOrderRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityOrderRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Order Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Order>(_entityOrderRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Order> Get(Expression<Func<Market_DomainModels.Models.Order, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Order, bool>>>(predicate);

            return _entityOrderRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Order> GetAll()
        {
            return _entityOrderRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Order entity)
        {
            var mappedEntityModel = _entityOrderRepository.Get(entity.ID);
            ModelMapper.Map(entity, mappedEntityModel);
            _entityOrderRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}