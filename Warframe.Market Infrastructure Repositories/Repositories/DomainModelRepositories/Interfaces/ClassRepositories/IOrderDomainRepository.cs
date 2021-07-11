using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface IOrderDomainRepository : IComplexClassDomainRepository<Order, Market_DomainModels.Models.Order>
    {
        void Create(ref Market_DomainModels.Models.Order entity, int userId);
    }
}
