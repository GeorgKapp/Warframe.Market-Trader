using System.Linq;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Implementation
{
    public class IconFormatRepository : IIconFormatRepository
    {
        public IconFormat Get(int entityID)
        {
            using (var context = new ReadOnlyEntityContext())
            {
                var entitities = context.Set<IconFormatType>().Where(p => p.ID == entityID);
                int entityCount = entitities.Count();

                if (entityCount == 0)
                    throw new EntityNotFoundException(nameof(IconFormat), entityID);

                if (entityCount > 1)
                    throw DataInconsistencyException.MultipleEntities(nameof(IconFormat), entityID);

                return entitities.Select(p => p.Type.ParseEnum<IconFormat>()).First();
            }
        }

        public IQueryable<IconFormat> GetAll()
        {
            using (var context = new ReadOnlyEntityContext())
            {
                return context.Set<RoleType>().Select(p => p.Type.ParseEnum<IconFormat>());
            }
        }
    }
}
