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
    public class LinkedAccountsRepository : ILinkedAccountsRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public LinkedAccountsRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts, LinkedAccounts>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<LinkedAccounts>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<LinkedAccounts>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            var searchedEntity = 
                DbContext.Set<LinkedAccounts>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            return ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(searchedEntity);
        }

        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> Get(Expression<Func<Market_DomainModels.Models.LinkedAccounts, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<LinkedAccounts, bool>>>(predicate);

            return DbContext.Set<LinkedAccounts>().Where(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }
        
        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            return DbContext.Set<LinkedAccounts>()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.LinkedAccounts>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<LinkedAccounts>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entity.ID);

            ModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            ModelMapper.Map(searchedEntity, entity);
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<LinkedAccounts>().Any(e => e.ID == entityID);
        }
    }
}