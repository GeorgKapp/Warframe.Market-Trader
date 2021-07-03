using System;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityTypeName, int entityId) : base($"ID: {entityId} has not been found in {entityTypeName}") { }
    }
}
