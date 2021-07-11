using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityFrameworkRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEntityUserRepository _efUserRepository;

        public UserRepository(IEntityUserRepository efUserRepository)
        {
            _efUserRepository = efUserRepository ?? throw new ArgumentNullException(nameof(efUserRepository));
        }

        public void Create(ref Market_DomainModels.Models.User entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.User, User>(entity);
            _efUserRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _efUserRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _efUserRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.User Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.User>(_efUserRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.User> Get(Expression<Func<Market_DomainModels.Models.User, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<User, bool>>>(predicate);

            return _efUserRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.User>(predicate));
        }


        public IEnumerable<Market_DomainModels.Models.User> GetAll()
        {
            return _efUserRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.User>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.User entity)
        {
            var mappedModel = ModelMapper.Map<User>(entity);
            _efUserRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}