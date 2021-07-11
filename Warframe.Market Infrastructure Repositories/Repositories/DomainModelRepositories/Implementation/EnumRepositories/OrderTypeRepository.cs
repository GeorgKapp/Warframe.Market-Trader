using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories;
using Warframe.Market_Infrastructure_Repositories.Utilities;
using OrderType = Warframe.Market_Infrastructure.OrderType;
using OrderTypeE = Warframe.Market_DomainModels.Enums.OrderType;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public OrderTypeRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public OrderTypeE Get(int entityID)
        {
            var foundEntity = DbContext.Set<OrderType>()
               .SingleOrDefault(predicate => predicate.ID == entityID)
               ?? throw new EntityNotFoundException(nameof(OrderType), entityID);

            return foundEntity.Type.ParseEnum<OrderTypeE>();
        }

        public IEnumerable<OrderTypeE> GetAll()
        {
            return DbContext.Set<OrderType>()
                .ToList()
                .Select(predicate => predicate.Type.ParseEnum<OrderTypeE>());
        }
    }
}
