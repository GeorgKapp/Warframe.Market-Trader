using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IClassDomainRepository<TDomain> 
        where TDomain : ADomainModel
    {
        void Create (ref TDomain entity);
        void Update (ref TDomain entity);
        void Delete (int entityID);
        bool Exists(int entityID);
        TDomain Get (int entityID);
        IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> predicate);
        IEnumerable<TDomain> GetAll();
    }
}
