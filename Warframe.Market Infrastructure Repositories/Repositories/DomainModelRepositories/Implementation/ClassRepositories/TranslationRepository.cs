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
    public class TranslationRepository : ITranslationRepository
    {
        private readonly IEntityTranslationRepository _efTranslationRepository;

        public TranslationRepository(IEntityTranslationRepository efTranslationRepository)
        {
            _efTranslationRepository = efTranslationRepository ?? throw new ArgumentNullException(nameof(efTranslationRepository));
        }

        public void Create(ref Market_DomainModels.Models.Translation entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Translation, Translation>(entity);
            _efTranslationRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _efTranslationRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _efTranslationRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Translation Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Translation>(_efTranslationRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Translation> Get(Expression<Func<Market_DomainModels.Models.Translation, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Translation, bool>>>(predicate);

            return _efTranslationRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Translation> GetAll()
        {
            return _efTranslationRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Translation entity)
        {
            var mappedModel = ModelMapper.Map<Translation>(entity);
            _efTranslationRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}