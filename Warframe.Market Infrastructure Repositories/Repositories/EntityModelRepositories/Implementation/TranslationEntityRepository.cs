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
    public class TranslationEntityRepository : ITranslationEntityRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private EntityContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public TranslationEntityRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void CreateMany(ref IEnumerable<Translation> entities)
        {
            DbContext.Translation.AddRange(entities);
            DbContext.SaveChanges();
        }

        public void Create(ref Translation entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<Translation>()
                .Where(predicate => predicate.ID == entityID)
                ?.SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(Translation), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<Translation>().Any(e => e.ID == entityID);
        }

        public Translation Get(int entityID)
        {
            return DbContext.Set<Translation>()
                ?.SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(Translation), entityID);
        }

        public IEnumerable<Translation> Get(Expression<Func<Translation, bool>> predicate)
        {
            return DbContext.Set<Translation>().Where(predicate);
        }

        public IEnumerable<Translation> GetAll()
        {
            return DbContext.Set<Translation>();
        }

        public void Update(ref Translation entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
