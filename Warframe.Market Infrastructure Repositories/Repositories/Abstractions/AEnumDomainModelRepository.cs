using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions
{
    public abstract class AEnumDomainModelRepository<TEntity, TEnum, TContext> : IEnumDomainModelRepository<TEntity, TEnum>
        where TEntity : class
        where TEnum : Enum
        where TContext : DbContext
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<TContext>();

        public AEnumDomainModelRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public TEnum Get(int entityID)
        {
            var entitities = DbContext.Set<TEntity>();
            var foundEntiteis = new List<TEntity>();
            foreach(var entity in entitities)
            {
                if((entity as dynamic).ID == entityID)
                {
                    foundEntiteis.Add(entity);
                }
            }

            int entityCount = foundEntiteis.Count();

            if (entityCount == 0)
                throw new EntityNotFoundException(typeof(TEnum).FullName, entityID);

            if (entityCount > 1)
                throw DataInconsistencyException.MultipleEntities(typeof(TEnum).FullName, entityID);

            return foundEntiteis.Select(p => ((p as dynamic).Type as string).ParseEnum<TEnum>()).First();
        }

        public IEnumerable<TEnum> GetAll()
        {
            //yield return seems buggy
            List<TEnum> results = new List<TEnum>();
            foreach (var entity in DbContext.Set<TEntity>())
                results.Add((TEnum)(((entity as dynamic).Type as string).ParseEnum<TEnum>() as Enum));

            return results;

        }
    }
}
