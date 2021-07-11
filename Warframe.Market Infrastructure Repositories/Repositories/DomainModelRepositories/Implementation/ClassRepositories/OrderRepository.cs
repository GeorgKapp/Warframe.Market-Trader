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
    public class OrderRepository : IOrderRepository
    {
        private readonly IEntityOrderRepository _efOrderRepository;

        public OrderRepository(IEntityOrderRepository efOrderRepository)
        {
            _efOrderRepository = efOrderRepository ?? throw new ArgumentNullException(nameof(efOrderRepository));
        }

        public void Create(ref Market_DomainModels.Models.Order entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Order, Order>(entity);
            _efOrderRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Create(ref Market_DomainModels.Models.Order entity, int userId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            _efOrderRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _efOrderRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Order Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Order>(_efOrderRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Order> Get(Expression<Func<Market_DomainModels.Models.Order, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Order, bool>>>(predicate);

            return _efOrderRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Order> GetAll()
        {
            return _efOrderRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Order>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Order entity)
        {
            var mappedModel = ModelMapper.Map<Order>(entity);
            _efOrderRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}