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
    public class TagRepository : ITagRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public TagRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public void Create(ref Market_DomainModels.Models.Tag entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Tag, Tag>(entity);
            mappedEntityObject.ID = 0;
            DbContext.Set<Tag>().Add(mappedEntityObject);

            DbContext.SaveChanges();
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            var entity = DbContext.Set<Tag>()
                .Where(predicate => predicate.ID == entityID)
                .SingleOrDefault()
                ?? throw new EntityNotFoundException(nameof(Tag), entityID);

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Market_DomainModels.Models.Tag Get(int entityID)
        {
            var searchedEntity =
                DbContext.Set<Tag>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(nameof(Tag), entityID);

            return ModelMapper.Map<Market_DomainModels.Models.Tag>(searchedEntity);
        }

        public IEnumerable<Market_DomainModels.Models.Tag> Get(Expression<Func<Market_DomainModels.Models.Tag, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Tag, bool>>>(predicate);

            return DbContext.Set<Tag>().Where(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Tag>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Tag> GetAll()
        {
            return DbContext.Set<Tag>()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Tag>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Tag entity)
        {
            var entityId = entity.ID;

            var searchedEntity =
                DbContext.Set<Tag>().SingleOrDefault(predicate => predicate.ID == entityId)
                ?? throw new EntityNotFoundException(nameof(Tag), entity.ID);

            ModelMapper.Map(entity, searchedEntity);
            DbContext.SaveChanges();
            ModelMapper.Map(searchedEntity, entity);
        }

        public bool Exists(int entityID)
        {
            return DbContext.Set<Tag>().Any(e => e.ID == entityID);
        }
    }
}
