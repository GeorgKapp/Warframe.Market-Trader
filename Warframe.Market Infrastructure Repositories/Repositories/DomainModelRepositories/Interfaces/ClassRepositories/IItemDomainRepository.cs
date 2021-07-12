using System.Collections.Generic;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface IItemDomainRepository : IComplexClassDomainRepository<Market_DomainModels.Models.Item, Market_DomainModels.Models.Item>
    {
        void Create(ref Market_DomainModels.Models.Item entity, int itemNameId, int? descriptionId = null, int? wikiLinkId = null);
        void Update(ref Market_DomainModels.Models.Item entity, int? itemNameId = null, int? descriptionId = null, int? wikiLinkId = null);
    }
}
