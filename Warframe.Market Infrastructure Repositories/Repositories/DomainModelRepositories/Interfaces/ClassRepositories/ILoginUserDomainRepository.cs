using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface ILoginUserDomainRepository
    {
        void Create(ref Market_DomainModels.Models.LoginUser entity, int userId, int linkedAccountId);
        void Update(ref Market_DomainModels.Models.LoginUser entity);
        void Delete(int entityID);
        bool Exists(int entityID);
        Market_DomainModels.Models.LoginUser Get(int entityID);
        IEnumerable<Market_DomainModels.Models.LoginUser> Get(Expression<Func<Market_DomainModels.Models.LoginUser, bool>> predicate);
        IEnumerable<Market_DomainModels.Models.LoginUser> GetAll();
    }
}
