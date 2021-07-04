using Warframe.Market_DbContextScope;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories
{
    public class OrderTypeRepository : AEnumDomainModelRepository<OrderType, Market_DomainModels.Enums.OrderType, EntityContext>, IOrderTypeRepository
    {
        public OrderTypeRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator) { }
    }
}
