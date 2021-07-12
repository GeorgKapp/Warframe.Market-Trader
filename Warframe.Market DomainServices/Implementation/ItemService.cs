using System;
using System.Linq;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_DomainServices.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_DomainServices.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IApiClient _apiClient;
        private readonly ITranslationDomainRepository _translationDomainRepository;
        public ItemService(IApiClient apiClient, ITranslationDomainRepository translationDomainRepository)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _translationDomainRepository = translationDomainRepository ?? throw new ArgumentNullException(nameof(translationDomainRepository));
        }

        public async Task DownloadAndUpdateAllItemsAndItemInformation()
        {
            var itemResults = await _apiClient.GetAllItemsAsync();
            if(itemResults.IsSuccess)
            {
                var createdDomainModel = new Market_DomainModels.Models.Item();
                foreach(var itemResult in itemResults.Result.Info.Items)
                {
                    createdDomainModel.UrlName = itemResult.UrlName;
                    var res = _translationDomainRepository.Get(p => p.En == itemResult.ItemName);
                }
            }
            _ = "";
        }
    }
}
