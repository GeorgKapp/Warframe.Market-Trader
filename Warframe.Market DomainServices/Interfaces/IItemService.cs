using System.Threading.Tasks;

namespace Warframe.Market_DomainServices.Interfaces
{
    public interface IItemService
    {
        Task DownloadAndUpdateAllItemsAndItemInformation();
    }
}
