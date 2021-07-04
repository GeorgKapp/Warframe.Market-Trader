using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories
{
    public class RegionRepository : AEnumDomainModelRepository<RegionType, Region, EntityContext>, IRegionRepository
    {
        public RegionRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator) { }
    }
}
