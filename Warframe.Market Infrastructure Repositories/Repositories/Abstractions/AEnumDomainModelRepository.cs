using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions
{
    public abstract class AEnumDomainModelRepository<TEntity, TDomainEnum, TContext> : IEnumDomainModelRepository<TEntity, TDomainEnum>
        where TEntity : AEntityEnumModel
        where TDomainEnum : Enum
        where TContext : DbContext
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<TContext>();

        public AEnumDomainModelRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public virtual TDomainEnum Get(int entityID)
        {
            var foundEntity = DbContext.Set<TEntity>()
                .SingleOrDefault(predicate => predicate.ID == entityID)
                ?? throw new EntityNotFoundException(typeof(TEntity).FullName, entityID);

            return foundEntity.Type.ParseEnum<TDomainEnum>();
        }

        public virtual IEnumerable<TDomainEnum> GetAll()
        {
            return DbContext.Set<TEntity>()
                .Select(predicate => predicate.Type.ParseEnum<TDomainEnum>());
        }
    }
}
