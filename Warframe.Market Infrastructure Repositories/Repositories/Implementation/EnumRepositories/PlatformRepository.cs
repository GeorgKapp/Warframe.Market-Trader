using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetDbContextOrThrow<EntityContext>();

        public PlatformRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public Platform Get(int entityID)
        {
            var foundEntity = DbContext.Set<PlatformType>()
               .SingleOrDefault(predicate => predicate.ID == entityID)
               ?? throw new EntityNotFoundException(nameof(PlatformType), entityID);

            return foundEntity.Type.ParseEnum<Platform>();
        }

        public IEnumerable<Platform> GetAll()
        {
            return DbContext.Set<PlatformType>().ToList()
                .Select(predicate => predicate.Type.ParseEnum<Platform>());
        }
    }
}
