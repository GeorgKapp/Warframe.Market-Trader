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
    public class LinkedAccountsDomainRepository : ILinkedAccountsDomainRepository
    {
        private readonly ILinkedAccountsEntityRepository _entityLinkedAccountsRepository;

        public LinkedAccountsDomainRepository(ILinkedAccountsEntityRepository entityLinkedAccountsRepository)
        {
            _entityLinkedAccountsRepository = entityLinkedAccountsRepository ?? throw new ArgumentNullException(nameof(entityLinkedAccountsRepository));
        }

        public void Create(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts, LinkedAccounts>(entity);
            _entityLinkedAccountsRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityLinkedAccountsRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityLinkedAccountsRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(_entityLinkedAccountsRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> Get(Expression<Func<Market_DomainModels.Models.LinkedAccounts, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<LinkedAccounts, bool>>>(predicate);

            return _entityLinkedAccountsRepository.Get(mappedPredicate)
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            return _entityLinkedAccountsRepository.GetAll()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedEntityModel = _entityLinkedAccountsRepository.Get(entity.ID);
            ModelMapper.Map(entity, mappedEntityModel);
            _entityLinkedAccountsRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}