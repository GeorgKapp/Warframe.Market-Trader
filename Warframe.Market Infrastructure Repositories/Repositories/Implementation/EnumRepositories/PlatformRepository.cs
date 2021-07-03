using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure.DbContextScope;
using Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories
{
    public class PlatformRepository : AEnumDomainModelRepository<PlatformType, Platform, EntityContext>, IPlatformRepository
    {
        public PlatformRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator) { }
    }
}
