using System.Threading.Tasks;

namespace Warframe.Market_DomainServices.Interfaces
{
    public interface IItemDomainService
    {
        Task CreateOrUpdateAllItems();
        Task CreateUpdateItemInformation(int itemId);
    }
}
