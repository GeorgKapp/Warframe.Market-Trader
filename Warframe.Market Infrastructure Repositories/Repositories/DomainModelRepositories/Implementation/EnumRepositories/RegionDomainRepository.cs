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
    public class RegionDomainRepository : IRegionDomainRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public RegionDomainRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public Region Get(int entityID)
        {
            var foundEntity = DbContext.Set<RegionType>()
               .SingleOrDefault(predicate => predicate.ID == entityID)
               ?? throw new EntityNotFoundException(nameof(RegionType), entityID);

            return foundEntity.Type.ParseEnum<Region>();
        }

        public IEnumerable<Region> GetAll()
        {
            return DbContext.Set<RegionType>()
                .ToList()
                .Select(predicate => predicate.Type.ParseEnum<Region>());
        }
    }
}
