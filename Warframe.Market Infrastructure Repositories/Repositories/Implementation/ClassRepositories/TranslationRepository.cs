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
    public class TranslationRepository : ITranslationRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public TranslationRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.Translation entity)
        {
            var mappedEntityObject = DomainModelMapper.Map<Market_DomainModels.Models.Translation, Translation>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<Translation>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            DomainModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<Translation>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(Translation), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<Translation>().Any(e => e.ID == entityID);
        }

        public Market_DomainModels.Models.Translation Get(int entityID)
        {
            var searchedEntity =
                DbContext.Set<Translation>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(Translation), entityID);

            return DomainModelMapper.Map<Market_DomainModels.Models.Translation>(searchedEntity);
        }

        public IEnumerable<Market_DomainModels.Models.Translation> Get(Expression<Func<Market_DomainModels.Models.Translation, bool>> predicate)
        {
            var mappedPredicate = DomainModelMapper.Map<Expression<Func<Translation, bool>>>(predicate);

            return DbContext.Set<Translation>().Where(mappedPredicate)
                .ToList()
                .Select(predicate => DomainModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }


        public IEnumerable<Market_DomainModels.Models.Translation> GetAll()
        {
            return DbContext.Set<Translation>()
                .ToList()
                .Select(predicate => DomainModelMapper.Map<Market_DomainModels.Models.Translation>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Translation entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<Translation>()
                .SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(Translation), entity.ID);

            DomainModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            DomainModelMapper.Map(searchedEntity, entity);
        }
    }
}
