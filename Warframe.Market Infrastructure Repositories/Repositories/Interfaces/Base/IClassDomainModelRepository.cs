using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IClassDomainModelRepository<TEntity, TClass> 
        where TEntity : class
        where TClass : ADomainModel
    {
        void Create (ref TClass entity);
        void Update (ref TClass entity);
        void Delete (int entityID);
        bool Exists(int entityID);
        TClass Get (int entityID);
        IEnumerable<TClass> Get(Expression<Func<TClass, bool>> predicate);
        IEnumerable<TClass> GetAll();
    }
}
