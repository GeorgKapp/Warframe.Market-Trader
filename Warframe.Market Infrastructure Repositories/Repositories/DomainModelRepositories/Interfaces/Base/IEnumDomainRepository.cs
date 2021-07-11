using System;
using System.Collections.Generic;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    /// <summary>
    /// Provides access to enum schema entities from the dabase as enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnumDomainRepository<TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Returns the enum corresponding to the "ID" property of the enum entitity
        /// </summary>
        /// <param name="entityID"></param>
        /// <returns></returns>
        TEnum Get(int entityID);

        /// <summary>
        /// Returns all enumerations of the enum entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEnum> GetAll();
    }
}
