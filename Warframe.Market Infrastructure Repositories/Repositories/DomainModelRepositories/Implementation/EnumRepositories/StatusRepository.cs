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
    public class StatusRepository : IStatusRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private DbContext DbContext => _ambientDbContextLocator.GetAmbientDbContextOrThrow<EntityContext>();

        public StatusRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public Status Get(int entityID)
        {
            var foundEntity = DbContext.Set<StatusType>()
               .SingleOrDefault(predicate => predicate.ID == entityID)
               ?? throw new EntityNotFoundException(nameof(StatusType), entityID);

            return foundEntity.Type.ParseEnum<Status>();
        }

        public IEnumerable<Status> GetAll()
        {
            return DbContext.Set<StatusType>()
                .ToList()
                .Select(predicate => predicate.Type.ParseEnum<Status>());
        }
    }
}
