using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface IOrderDomainRepository
    {
        void Create(ref Market_DomainModels.Models.Order entity, int userId);
        void Update(ref Market_DomainModels.Models.Order entity);
        void Delete(int entityID);
        bool Exists(int entityID);
        Market_DomainModels.Models.Order Get(int entityID);
        IEnumerable<Market_DomainModels.Models.Order> Get(Expression<Func<Market_DomainModels.Models.Order, bool>> predicate);
        IEnumerable<Market_DomainModels.Models.Order> GetAll();
    }
}
