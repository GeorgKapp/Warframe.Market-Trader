using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
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
            entity = Mapper.Map<LinkedAccounts, Market_DomainModels.Models.LinkedAccounts>(createdEntityObject);
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            var searchedEntity = 
                DbContext.Set<LinkedAccounts>().SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(LinkedAccounts), entityID);

            var result = new Market_DomainModels.Models.LinkedAccounts(entityID);
            result = Mapper.Map<LinkedAccounts, Market_DomainModels.Models.LinkedAccounts>(searchedEntity);
            return result;
        }

        public IQueryable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ref Market_DomainModels.Models.LinkedAccounts entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<LinkedAccounts>().Any(e => e.ID == entityID);
        }
    }
}
