using System;
using System.Linq;

namespace Warframe.Market_Infrastructure_Repositories.Base
{
    /// <summary>
    /// Provides access to enum schema entities from the dabase as enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnumRepository<T> where T : Enum
    {
        /// <summary>
        /// Returns the enum corresponding to the id of the enum entitity
        /// </summary>
        /// <param name="entityID"></param>
        /// <returns></returns>
        T Get(int entityID);

        /// <summary>
        /// Returns all enumerations of the enum entity
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
    }
}
