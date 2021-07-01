using System.Linq;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Implementation
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        public Market_DomainModels.Enums.OrderType Get(int entityID)
        {
            using (var context = new ReadOnlyEntityContext())
            {
                var entitities = context.Set<OrderType>().Where(p => p.ID == entityID);
                int entityCount = entitities.Count();

                if(entityCount == 0)
                    throw new EntityNotFoundException(nameof(Market_DomainModels.Enums.OrderType), entityID);

                if(entityCount > 1)
                    throw DataInconsistencyException.MultipleEntities(nameof(Market_DomainModels.Enums.OrderType), entityID);

                return entitities.Select(p => p.Type.ParseEnum<Market_DomainModels.Enums.OrderType>()).First();
            }
        }

        public IQueryable<Market_DomainModels.Enums.OrderType> GetAll()
        {
            using (var context = new ReadOnlyEntityContext())
            {
                return context.Set<OrderType>().Select(p => p.Type.ParseEnum<Market_DomainModels.Enums.OrderType>());
            }
        }
    }
}
