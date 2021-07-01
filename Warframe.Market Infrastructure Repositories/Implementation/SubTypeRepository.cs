﻿using System.Linq;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Implementation
{
    public class SubTypeRepository : ISubTypeRepository
    {
        public SubType Get(int entityID)
        {
            using (var context = new ReadOnlyEntityContext())
            {
                var entitities = context.Set<SubTypeType>().Where(p => p.ID == entityID);
                int entityCount = entitities.Count();

                if (entityCount == 0)
                    throw new EntityNotFoundException(nameof(SubType), entityID);

                if (entityCount > 1)
                    throw DataInconsistencyException.MultipleEntities(nameof(SubType), entityID);

                return entitities.Select(p => p.Type.ParseEnum<SubType>()).First();
            }
        }

        public IQueryable<SubType> GetAll()
        {
            using (var context = new ReadOnlyEntityContext())
            {
                return context.Set<RoleType>().Select(p => p.Type.ParseEnum<SubType>());
            }
        }
    }
}
