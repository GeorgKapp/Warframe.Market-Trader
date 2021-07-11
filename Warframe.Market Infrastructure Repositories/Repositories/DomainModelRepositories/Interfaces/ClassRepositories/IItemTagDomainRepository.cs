using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface IItemTagDomainRepository : IComplexClassDomainRepository<ItemTag, Market_DomainModels.Models.ItemTag>
    {
        Market_DomainModels.Models.ItemTag Create(int itemId, int tagId);
        void Update(ref Market_DomainModels.Models.ItemTag entity, int tagId);
    }
}
