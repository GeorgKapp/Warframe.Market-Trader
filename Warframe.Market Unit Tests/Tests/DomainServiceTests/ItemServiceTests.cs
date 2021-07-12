using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Implementation;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainServices.Implementation;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();



        [TestMethod("1. Get or udpate all items")]
        public async Task Test1GetAllItems()
        {
            ItemService service = new ItemService(new ApiClient());
            await service.DownloadAndUpdateAllItemsAndItemInformation();
        }
    }
}
