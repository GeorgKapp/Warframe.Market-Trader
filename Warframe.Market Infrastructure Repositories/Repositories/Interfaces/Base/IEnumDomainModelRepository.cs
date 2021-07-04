using System;
using System.Collections.Generic;
using Warframe.Market_Infrastructure;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    /// <summary>
    /// Provides access to enum schema entities from the dabase as enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnumDomainModelRepository<TEntity, TDomainEnum>
        where TEntity : AEntityEnumModel
        where TDomainEnum : Enum
    {
        /// <summary>
        /// Returns the enum corresponding to the "ID" property of the enum entitity
        /// </summary>
        /// <param name="entityID"></param>
        /// <returns></returns>
        TDomainEnum Get(int entityID);

        /// <summary>
        /// Returns all enumerations of the enum entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<TDomainEnum> GetAll();
    }
}
