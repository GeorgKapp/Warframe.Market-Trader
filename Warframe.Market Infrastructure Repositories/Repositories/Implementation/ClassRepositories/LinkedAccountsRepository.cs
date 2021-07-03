using AutoMapper;
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
    public class LinkedAccountsRepository : ILinkedAccountsRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        internal static IMapper Mapper { get; } = new MapperConfiguration(
            cfg => cfg.AddProfile<LinkedAccountsMappingProfile>())
                .CreateMapper();

        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public LinkedAccountsRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var mappedEntityObject = Mapper.Map<Market_DomainModels.Models.LinkedAccounts, LinkedAccounts>(entity);
            var createdEntityObject = DbContext.Set<LinkedAccounts>().Add(mappedEntityObject);

            DbContext.SaveChanges();

            entity = new Market_DomainModels.Models.LinkedAccounts(createdEntityObject.ID);
            Mapper.Map(createdEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<LinkedAccounts>().Where(predicate => predicate.ID == entityID).SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            var searchedEntity = 
                DbContext.Set<LinkedAccounts>().SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            var result = new Market_DomainModels.Models.LinkedAccounts(entityID);
            Mapper.Map(searchedEntity, result);
            return result;
        }

        public Market_DomainModels.Models.LinkedAccounts Get(Expression<Func<LinkedAccounts, bool>> predicate)
        {
            var searchedEntity =
                DbContext.Set<LinkedAccounts>().SingleOrDefault(predicate)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), predicate.ToString());

            var result = new Market_DomainModels.Models.LinkedAccounts(searchedEntity.ID);
            Mapper.Map(searchedEntity, result);
            return result;
        }
        
        public IEnumerable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            var results = new List<Market_DomainModels.Models.LinkedAccounts>();
            foreach (var entity in DbContext.Set<LinkedAccounts>())
            {
                var domainModel = new Market_DomainModels.Models.LinkedAccounts(entity.ID);
                Mapper.Map(entity, domainModel);
                results.Add(domainModel);
            }
            return results;
        }

        public void Update(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<LinkedAccounts>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entity.ID);

            Mapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            Mapper.Map(searchedEntity, entity);
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<LinkedAccounts>().Any(e => e.ID == entityID);
        }
    }
}
