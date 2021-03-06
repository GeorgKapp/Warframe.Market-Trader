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
    public class LoginUserEntityRepository : ILoginUserEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private EntityContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public LoginUserEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void CreateMany(ref IEnumerable<LoginUser> entities)
        {
            DbContext.LoginUser.AddRange(entities);
            DbContext.SaveChanges();
        }

        public void Create(ref LoginUser entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<LoginUser>()
                .Where(predicate => predicate.ID == entityID)
                ?.SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(LoginUser), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<LoginUser>().Any(e => e.ID == entityID);
        }

        public LoginUser Get(int entityID)
        {
            return DbContext.Set<LoginUser>()
                ?.SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(LoginUser), entityID);
        }

        public IEnumerable<LoginUser> Get(Expression<Func<LoginUser, bool>> predicate)
        {
            return DbContext.Set<LoginUser>().Where(predicate);
        }

        public IEnumerable<LoginUser> GetAll()
        {
            return DbContext.Set<LoginUser>();
        }

        public void Update(ref LoginUser entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
