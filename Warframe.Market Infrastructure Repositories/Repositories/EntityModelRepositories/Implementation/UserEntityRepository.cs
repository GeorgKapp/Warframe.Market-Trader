using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation
{
    public class UserEntityRepository : IUserEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private EntityContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public UserEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void CreateMany(ref IEnumerable<User> entities)
        {
            DbContext.User.AddRange(entities);
            DbContext.SaveChanges();
        }

        public void Create(ref User entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<User>()
                .Where(predicate => predicate.ID == entityID)
                ?.SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(User), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<User>().Any(e => e.ID == entityID);
        }

        public User Get(int entityID)
        {
            return DbContext.Set<User>()
                ?.SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(User), entityID);
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Set<User>().Where(predicate);
        }

        public IEnumerable<User> GetAll()
        {
            return DbContext.Set<User>();
        }

        public void Update(ref User entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
