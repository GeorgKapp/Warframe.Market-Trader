using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure.DbContextScope;
using Warframe.Market_Infrastructure_Repositories.Mapping.Profiles;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        internal static IMapper Mapper { get; } = new MapperConfiguration(
             config =>
             {
                 config.AddExpressionMapping();
                 config.AddProfile<UserMappingProfile>();
             }).CreateMapper();

        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public UserRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.User entity)
        {
            var mappedEntityObject = Mapper.Map<Market_DomainModels.Models.User, User>(entity);
            var createdEntityObject = DbContext.Set<User>().Add(mappedEntityObject);

            DbContext.SaveChanges();

            entity = new Market_DomainModels.Models.User(createdEntityObject.ID);
            Mapper.Map(createdEntityObject, entity);
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

            var result = new Market_DomainModels.Models.User(entityID);
            Mapper.Map(searchedEntity, result);
            return result;
        }

        public IEnumerable<Market_DomainModels.Models.User> Get(Expression<Func<Market_DomainModels.Models.User, bool>> predicate)
        {
            var results = new List<Market_DomainModels.Models.User>();

            var mappedPredicate = Mapper.Map<Expression<Func<User, bool>>>(predicate);
            foreach (var entity in DbContext.Set<User>().Where(mappedPredicate))
            {
                var domainModel = new Market_DomainModels.Models.User(entity.ID);
                Mapper.Map(entity, domainModel);
                results.Add(domainModel);
            }
            return results;
        }


        public IEnumerable<Market_DomainModels.Models.User> GetAll()
        {
            var results = new List<Market_DomainModels.Models.User>();
            foreach (var entity in DbContext.Set<User>())
            {
                var domainModel = new Market_DomainModels.Models.User(entity.ID);
                Mapper.Map(entity, domainModel);
                results.Add(domainModel);
            }
            return results;
        }

        public void Update(ref Market_DomainModels.Models.User entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<User>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(User), entity.ID);

            Mapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            Mapper.Map(searchedEntity, entity);
        }

    }
}
