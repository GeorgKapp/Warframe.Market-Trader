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
    public class ItemTagDomainRepository : IItemTagDomainRepository
    {
        private readonly IItemTagEntityRepository _entityItemTagRepository;
        private readonly ITagEntityRepository _entityTagRepository;
        private readonly IItemEntityRepository _entityItemRepository;

        public ItemTagDomainRepository(IItemTagEntityRepository entityItemTagRepository, ITagEntityRepository entityTagRepository, IItemEntityRepository entityItemRepository)
        {
            _entityItemTagRepository = entityItemTagRepository ?? throw new ArgumentNullException(nameof(entityItemTagRepository));
            _entityTagRepository = entityTagRepository ?? throw new ArgumentNullException(nameof(entityTagRepository));
            _entityItemRepository = entityItemRepository ?? throw new ArgumentNullException(nameof(entityItemRepository));
        }

        public Market_DomainModels.Models.ItemTag Create(int itemId, int tagId)
        {
            var mappedEntityObject = new ItemTag
            {
                Tag = _entityTagRepository.Get(tagId),
                Item = _entityItemRepository.Get(itemId)
            };
            _entityItemTagRepository.Create(ref mappedEntityObject);
            return ModelMapper.Map<Market_DomainModels.Models.ItemTag>(mappedEntityObject);
        }

        public void Delete(int entityID)
        {
            _entityItemTagRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityItemTagRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.ItemTag Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.ItemTag>(_entityItemTagRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.ItemTag> Get(Expression<Func<Market_DomainModels.Models.ItemTag, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<ItemTag, bool>>>(predicate);

            return _entityItemTagRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.ItemTag>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.ItemTag> GetAll()
        {
            return _entityItemTagRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.ItemTag>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.ItemTag entity, int tagId)
        {
            var mappedEntityModel = _entityItemTagRepository.Get(entity.ID);
            mappedEntityModel.Tag = _entityTagRepository.Get(tagId);
            _entityItemTagRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}