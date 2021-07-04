using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.User entity)
        {
            var mappedEntityObject = DomainModelMapper.Map<Market_DomainModels.Models.User, User>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<User>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            DomainModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<User>().Where(predicate => predicate.ID == entityID).SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(User), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<User>().Any(e => e.ID == entityID);
        }

        public Market_DomainModels.Models.User Get(int entityID)
        {
            var searchedEntity =
                DbContext.Set<User>().SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(User), entityID);

            return DomainModelMapper.Map<Market_DomainModels.Models.User>(searchedEntity);
        }

        public IEnumerable<Market_DomainModels.Models.User> Get(Expression<Func<Market_DomainModels.Models.User, bool>> predicate)
        {
            var results = new List<Market_DomainModels.Models.User>();
            var mappedPredicate = DomainModelMapper.Map<Expression<Func<User, bool>>>(predicate);

            foreach (var entity in DbContext.Set<User>().Where(mappedPredicate))
            {
                results.Add(DomainModelMapper.Map<Market_DomainModels.Models.User>(entity));
            }
            return results;
        }


        public IEnumerable<Market_DomainModels.Models.User> GetAll()
        {
            var results = new List<Market_DomainModels.Models.User>();
            foreach (var entity in DbContext.Set<User>())
            {
                results.Add(DomainModelMapper.Map<Market_DomainModels.Models.User>(entity));
            }
            return results;
        }

        public void Update(ref Market_DomainModels.Models.User entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<User>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(User), entity.ID);

            DomainModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            DomainModelMapper.Map(searchedEntity, entity);
        }
    }
}
