using System.Linq;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Implementation
{
    public class RegionRepository : IRegionRepository
    {
        public Region Get(int entityID)
        {
            using (var context = new ReadOnlyEntityContext())
            {
                var entitities = context.Set<RegionType>().Where(p => p.ID == entityID);
                int entityCount = entitities.Count();

                if (entityCount == 0)
                    throw new EntityNotFoundException(nameof(Region), entityID);

                if (entityCount > 1)
                    throw DataInconsistencyException.MultipleEntities(nameof(Region), entityID);

                return entitities.Select(p => p.Type.ParseEnum<Region>()).First();
            }
        }

        public IQueryable<Region> GetAll()
        {
            using (var context = new ReadOnlyEntityContext())
            {
                return context.Set<RoleType>().Select(p => p.Type.ParseEnum<Region>());
            }
        }
    }
}
