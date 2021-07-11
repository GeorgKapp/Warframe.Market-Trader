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
    public class ItemDomainRepository : IItemDomainRepository
    {
        private readonly IItemEntityRepository _entityItemRepository;
        private readonly ITranslationEntityRepository _entityTranslationRepository;

        public ItemDomainRepository(IItemEntityRepository entityItemRepository, ITranslationEntityRepository entityTranslationRepository)
        {
            _entityItemRepository = entityItemRepository ?? throw new ArgumentNullException(nameof(entityItemRepository));
            _entityTranslationRepository = entityTranslationRepository ?? throw new ArgumentNullException(nameof(entityTranslationRepository));
        }

        public void Create(ref Market_DomainModels.Models.Item entity, int descriptionId, int wikiLinkId, int itemNameId)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Item, Item>(entity);
            mappedEntityObject.Translation = _entityTranslationRepository.Get(descriptionId);
            mappedEntityObject.Translation1 = _entityTranslationRepository.Get(wikiLinkId);
            mappedEntityObject.Translation2 = _entityTranslationRepository.Get(itemNameId);
            _entityItemRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityItemRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityItemRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Item Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Item>(_entityItemRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Item> Get(Expression<Func<Market_DomainModels.Models.Item, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Item, bool>>>(predicate);

            return _entityItemRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Item>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Item> GetAll()
        {
            return _entityItemRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Item>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Item entity)
        {
            var mappedEntityModel = _entityItemRepository.Get(entity.ID);
            ModelMapper.Map(entity, mappedEntityModel);
            _entityItemRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}