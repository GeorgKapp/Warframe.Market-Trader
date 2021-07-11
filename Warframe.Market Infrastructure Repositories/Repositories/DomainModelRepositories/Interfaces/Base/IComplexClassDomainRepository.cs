using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IComplexClassDomainRepository<TEntity, TDomain> 
        where TEntity : class
        where TDomain : ADomainModel
    {
        void Delete (int entityID);
        bool Exists(int entityID);
        TDomain Get (int entityID);
        IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> predicate);
        IEnumerable<TDomain> GetAll();
    }
}
