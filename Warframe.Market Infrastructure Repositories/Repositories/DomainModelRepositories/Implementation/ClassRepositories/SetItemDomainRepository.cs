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
    public class SetItemDomainRepository : ISetItemDomainRepository
    {
        private readonly ISetItemEntityRepository _entitySetItemRepository;
        private readonly IItemEntityRepository _entityItemRepository;

        public SetItemDomainRepository(ISetItemEntityRepository entitySetItemRepository, IItemEntityRepository entityItemRepository)
        {
            _entitySetItemRepository = entitySetItemRepository ?? throw new ArgumentNullException(nameof(entitySetItemRepository));
            _entityItemRepository = entityItemRepository ?? throw new ArgumentNullException(nameof(entityItemRepository));
        }

        public Market_DomainModels.Models.SetItem Create(int parentItemId, int childItemId, byte childQuantity)
        {
            var mappedEntityObject = new SetItem
            {
                Item = _entityItemRepository.Get(childItemId),
                Item1 = _entityItemRepository.Get(parentItemId),
                ChildQuantity = childQuantity
            };
            _entitySetItemRepository.Create(ref mappedEntityObject);
            return ModelMapper.Map<Market_DomainModels.Models.SetItem>(mappedEntityObject);
        }

        public void Delete(int entityID)
        {
            _entitySetItemRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entitySetItemRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.SetItem Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.SetItem>(_entitySetItemRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.SetItem> Get(Expression<Func<Market_DomainModels.Models.SetItem, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<SetItem, bool>>>(predicate);

            return _entitySetItemRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.SetItem>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.SetItem> GetAll()
        {
            return _entitySetItemRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.SetItem>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.SetItem entity, int parentItemId, int childItemId, byte childQuantity)
        {
            var mappedEntityModel = _entitySetItemRepository.Get(entity.ID);
            mappedEntityModel.Item = _entityItemRepository.Get(childItemId);
            mappedEntityModel.Item1 = _entityItemRepository.Get(parentItemId);
            mappedEntityModel.ChildQuantity = childQuantity;
            _entitySetItemRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }

        public void Update(ref Market_DomainModels.Models.SetItem entity, byte childQuantity)
        {
            var mappedEntityModel = _entitySetItemRepository.Get(entity.ID);
            mappedEntityModel.ChildQuantity = childQuantity;
            _entitySetItemRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}