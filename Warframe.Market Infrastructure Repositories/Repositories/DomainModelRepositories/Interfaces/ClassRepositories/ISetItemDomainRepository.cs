using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface ISetItemDomainRepository : IComplexClassDomainRepository<SetItem, Market_DomainModels.Models.SetItem>
    {
        Market_DomainModels.Models.SetItem Create(int parentItemId, int childItemId, byte childQuantity);
        void Update(ref Market_DomainModels.Models.SetItem entity, int parentItemId, int childItemId, byte childQuantity);
        void Update(ref Market_DomainModels.Models.SetItem entity, byte childQuantity);
    }
}
