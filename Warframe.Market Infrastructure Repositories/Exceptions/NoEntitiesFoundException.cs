using System;

namespace Warframe.Market_Infrastructure_Repositories.Exceptions
{
    public class NoEntitiesFoundException : Exception
    {
        public NoEntitiesFoundException(string entityApiType) : base($"ID: No Entities have been found in {entityApiType} during api call") { }
    }
}
