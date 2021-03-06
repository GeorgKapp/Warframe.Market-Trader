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
    public class LinkedAccountsEntityRepository : ILinkedAccountsEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private EntityContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public LinkedAccountsEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void CreateMany(ref IEnumerable<LinkedAccounts> entities)
        {
            DbContext.LinkedAccounts.AddRange(entities);
            DbContext.SaveChanges();
        }

        public void Create(ref LinkedAccounts entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<LinkedAccounts>()
                .Where(predicate => predicate.ID == entityID)
                ?.SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<LinkedAccounts>().Any(e => e.ID == entityID);
        }

        public LinkedAccounts Get(int entityID)
        {
            return DbContext.Set<LinkedAccounts>()
                ?.SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);
        }

        public IEnumerable<LinkedAccounts> Get(Expression<Func<LinkedAccounts, bool>> predicate)
        {
            return DbContext.Set<LinkedAccounts>().Where(predicate);
        }

        public IEnumerable<LinkedAccounts> GetAll()
        {
            return DbContext.Set<LinkedAccounts>();
        }

        public void Update(ref LinkedAccounts entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
