using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.EnumRepositories
{
    public interface IOrderTypeRepository : IEnumDomainModelRepository<Market_Infrastructure.OrderType, Market_DomainModels.Enums.OrderType> { }
}
