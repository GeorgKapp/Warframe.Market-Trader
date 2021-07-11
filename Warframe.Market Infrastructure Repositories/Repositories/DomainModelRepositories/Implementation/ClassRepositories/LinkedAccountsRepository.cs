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
    public class LinkedAccountsRepository : ILinkedAccountsRepository
    {
        private readonly IEntityLinkedAccountsRepository _efLinkedAccountsRepository;

        public LinkedAccountsRepository(IEntityLinkedAccountsRepository efLinkedAccountsRepository)
        {
            _efLinkedAccountsRepository = efLinkedAccountsRepository ?? throw new ArgumentNullException(nameof(efLinkedAccountsRepository));
        }

        public void Create(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts, LinkedAccounts>(entity);
            _efLinkedAccountsRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _efLinkedAccountsRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _efLinkedAccountsRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(_efLinkedAccountsRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> Get(Expression<Func<Market_DomainModels.Models.LinkedAccounts, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<LinkedAccounts, bool>>>(predicate);

            return _efLinkedAccountsRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            return _efLinkedAccountsRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedModel = ModelMapper.Map<LinkedAccounts>(entity);
            _efLinkedAccountsRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}