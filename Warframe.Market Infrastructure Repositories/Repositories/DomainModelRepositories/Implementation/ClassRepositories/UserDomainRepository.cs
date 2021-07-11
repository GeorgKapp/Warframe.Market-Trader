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
    public class UserDomainRepository : IUserDomainRepository
    {
        private readonly IUserEntityRepository _entityUserRepository;

        public UserDomainRepository(IUserEntityRepository entityUserRepository)
        {
            _entityUserRepository = entityUserRepository ?? throw new ArgumentNullException(nameof(entityUserRepository));
        }

        public void Create(ref Market_DomainModels.Models.User entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.User, User>(entity);
            _entityUserRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityUserRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityUserRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.User Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.User>(_entityUserRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.User> Get(Expression<Func<Market_DomainModels.Models.User, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<User, bool>>>(predicate);

            return _entityUserRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.User>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.User> GetAll()
        {
            return _entityUserRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.User>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.User entity)
        {
            var mappedModel = ModelMapper.Map<User>(entity);
            _entityUserRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}