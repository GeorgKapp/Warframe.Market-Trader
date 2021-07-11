using System;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions
{
    public class DataInconsistencyException : Exception
    {
        public DataInconsistencyException(string message) : base(message) { }

        public static DataInconsistencyException MultipleEntities(string entityTypeName, int entityId)
            => new DataInconsistencyException($"ID: {entityId} has been found multiple times in {entityTypeName}");
    }
}
