using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Implementation;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainServices.Implementation;
using Warframe.Market_DomainServices.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();
        IApiClient _apiClient = new ApiClient();



        [TestMethod("1. Get or udpate all items")]
        public async Task Test1GetAllItems()
        {
            using (var scope = _dbContextScopeFactory.Create())
            {
                IItemEntityRepository entityItemRepository = new ItemEntityRepository(_ambientDbContextLocator);
                ITranslationEntityRepository entityTranslationRepository = new TranslationEntityRepository(_ambientDbContextLocator);
                ITranslationDomainRepository translationDomainRepository = new TranslationDomainRepository(entityTranslationRepository);
                ITranslationDomainService translationDomainService = new TranslationDomainService(translationDomainRepository);

                ItemDomainService service = new ItemDomainService(_apiClient, new ItemDomainRepository(entityItemRepository, entityTranslationRepository), translationDomainService, _dbContextScopeFactory);
                await service.CreateOrUpdateAllItems();
                await scope.SaveChangesAsync();
            }
        }
    }
}
