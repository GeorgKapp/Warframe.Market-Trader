using System;
using System.Linq;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainServices.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_DomainServices.Implementation
{
    public class ItemDomainService : IItemDomainService
    {
        private readonly IApiClient _apiClient;
        private readonly IItemDomainRepository _itemDomainRepository;
        private readonly ITranslationDomainService _translationDomainService;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
       
        public ItemDomainService(
            IApiClient apiClient, 
            IItemDomainRepository itemDomainRepository, 
            ITranslationDomainService translationDomainService, 
            IDbContextScopeFactory dbContextScopeFactory) 
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _itemDomainRepository = itemDomainRepository ?? throw new ArgumentNullException(nameof(itemDomainRepository));
            _translationDomainService = translationDomainService ?? throw new ArgumentNullException(nameof(translationDomainService));
            _dbContextScopeFactory = dbContextScopeFactory ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
        }

        public async Task CreateOrUpdateAllItems()
        {
            var itemResults = await _apiClient.GetAllItemsAsync();

            if (!itemResults.IsSuccess) throw itemResults.Exception;
            if (itemResults.Result.Info.Items.Length == 0) throw new NoEntitiesFoundException(nameof(itemResults.Result.Info.Items));

            using (var contextScope = _dbContextScopeFactory.Create())
            {
                foreach (var itemResult in itemResults.Result.Info.Items)
                {
                    var foundItemDomainModel = _itemDomainRepository.Get(p => p.ExternalID == itemResult.Id).SingleOrDefault();
                    var itemNameTranslationModel = _translationDomainService.CreateOrGetTranslationByEnglishValue(itemResult.ItemName);

                    if (foundItemDomainModel is null)
                    {
                        var newItemDomainModel = CreateItemModel(itemResult);
                        _itemDomainRepository.Create(ref newItemDomainModel, itemNameTranslationModel.ID);
                    }
                    else
                    {
                        UpdateItemModel(ref foundItemDomainModel, itemResult);
                        _itemDomainRepository.Update(ref foundItemDomainModel, itemNameTranslationModel.ID);
                    }
                }
                await contextScope.SaveChangesAsync();
            }
        }

        public Task CreateUpdateItemInformation(int itemId)
        {
            throw new NotImplementedException();
        }

        private Market_DomainModels.Models.Item CreateItemModel(Market_Api.JsonData.Content.Items.Item itemResult)
        {
            return new Market_DomainModels.Models.Item
            {
                UrlName = itemResult.UrlName,
                Thumb = itemResult.Thumb,
                ExternalID = itemResult.Id
            };
        }

        private void UpdateItemModel(ref Market_DomainModels.Models.Item item, Market_Api.JsonData.Content.Items.Item itemResult)
        {
            item.UrlName = itemResult.UrlName;
            item.Thumb = itemResult.Thumb;
            item.ExternalID = itemResult.Id;
        }
    }
}
