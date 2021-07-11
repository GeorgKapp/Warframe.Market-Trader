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
    public class TranslationDomainRepository : ITranslationDomainRepository
    {
        private readonly ITranslationEntityRepository _entityTranslationRepository;

        public TranslationDomainRepository(ITranslationEntityRepository entityTranslationRepository)
        {
            _entityTranslationRepository = entityTranslationRepository ?? throw new ArgumentNullException(nameof(entityTranslationRepository));
        }

        public void Create(ref Market_DomainModels.Models.Translation entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Translation, Translation>(entity);
            _entityTranslationRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityTranslationRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityTranslationRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Translation Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Translation>(_entityTranslationRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Translation> Get(Expression<Func<Market_DomainModels.Models.Translation, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Translation, bool>>>(predicate);

            return _entityTranslationRepository.Get(mappedPredicate)
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Translation> GetAll()
        {
            return _entityTranslationRepository.GetAll()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Translation entity)
        {
            var mappedEntityModel = _entityTranslationRepository.Get(entity.ID);
            ModelMapper.Map(entity, mappedEntityModel);
            _entityTranslationRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}