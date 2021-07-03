using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories
{
    public interface IRegionRepository : IEnumDomainModelRepository<RegionType, Region> { }
}
