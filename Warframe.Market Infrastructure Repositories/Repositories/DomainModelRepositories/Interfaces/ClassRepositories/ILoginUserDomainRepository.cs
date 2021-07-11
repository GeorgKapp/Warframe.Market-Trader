using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface ILoginUserDomainRepository : IComplexClassDomainRepository<LoginUser, Market_DomainModels.Models.LoginUser>
    {
        void Create(ref Market_DomainModels.Models.LoginUser entity, int userId, int linkedAccountId);
        void Update(ref Market_DomainModels.Models.LoginUser entity);
    }
}
