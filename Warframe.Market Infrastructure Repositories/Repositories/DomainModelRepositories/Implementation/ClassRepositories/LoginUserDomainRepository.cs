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
    public class LoginUserDomainRepository : ILoginUserDomainRepository
    {
        private readonly ILoginUserEntityRepository _entityLoginUserRepository;
        private readonly IUserEntityRepository _entityUserRepository;
        private readonly ILinkedAccountsEntityRepository _entityLinkedAccountsRepository;

        public LoginUserDomainRepository(ILoginUserEntityRepository entityLoginUserRepository, IUserEntityRepository entityUserRepository, ILinkedAccountsEntityRepository entityLinkedAccountsRepository)
        {
            _entityLoginUserRepository = entityLoginUserRepository ?? throw new ArgumentNullException(nameof(entityLoginUserRepository));
            _entityUserRepository = entityUserRepository ?? throw new ArgumentNullException(nameof(entityUserRepository));
            _entityLinkedAccountsRepository = entityLinkedAccountsRepository ?? throw new ArgumentNullException(nameof(entityLinkedAccountsRepository));
        }

        public void Create(ref Market_DomainModels.Models.LoginUser entity, int userId, int linkedAccountId)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.LoginUser, LoginUser>(entity);
            mappedEntityObject.User = _entityUserRepository.Get(userId);
            mappedEntityObject.LinkedAccounts = _entityLinkedAccountsRepository.Get(linkedAccountId);
            _entityLoginUserRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _entityLoginUserRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _entityLoginUserRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.LoginUser Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.LoginUser>(_entityLoginUserRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.LoginUser> Get(Expression<Func<Market_DomainModels.Models.LoginUser, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<LoginUser, bool>>>(predicate);

            return _entityLoginUserRepository.Get(mappedPredicate)
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LoginUser>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.LoginUser> GetAll()
        {
            return _entityLoginUserRepository.GetAll()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LoginUser>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.LoginUser entity)
        {
            var mappedEntityModel = _entityLoginUserRepository.Get(entity.ID);
            ModelMapper.Map(entity, mappedEntityModel);
            _entityLoginUserRepository.Update(ref mappedEntityModel);
            ModelMapper.Map(mappedEntityModel, entity);
        }
    }
}