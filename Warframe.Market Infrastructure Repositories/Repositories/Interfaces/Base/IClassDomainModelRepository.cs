using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IClassDomainModelRepository<TDomainModel, TEntityModel> where TDomainModel : ADomainModel
    {
        void Create (ref TDomainModel entity);
        void Update (ref TDomainModel entity);
        void Delete (int entityID);
        bool Exists(int entityID);
        TDomainModel Get (int entityID);
        TDomainModel Get(Expression<Func<TEntityModel, bool>> predicate);
        IEnumerable<TDomainModel> GetAll();
    }
}
