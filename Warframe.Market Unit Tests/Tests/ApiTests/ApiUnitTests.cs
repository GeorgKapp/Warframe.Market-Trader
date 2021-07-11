using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using Warframe.Market_Api.Api.Clients.Implementation;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_Api.Api.Data;
using Warframe.Market_Api.JsonData.Content;

namespace Warframe.Market_Unit_Tests
{
    [TestCategory("Api Unit Tests")]
    [TestClass]
    public class ApiUnitTests
    {
        private static IApiClient _client;

        private const string AshPrimeSetLink = "ash_prime_set";
        private const string GladiatorMightModLink = "gladiator_might";
        private const string AxiA6RelicLink = "axi_n6_relic";
        private const string CompanionRivenModVeiledLink = "companion_weapon_riven_mod_(veiled)";
        private const string LegendaryFusionCoreLink = "legendary_fusion_core";

        [ClassInitialize]
        public static void InitializeSetup(TestContext context)
        {
            _client = new ApiClient();
        }

        [TestMethod("1. Login Request")]
        public void Test1LoginAsync()
        {
            var result = LogIn();
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod("2. Recieving of Item Information")]
        [DataRow(AshPrimeSetLink)]
        [DataRow(GladiatorMightModLink)]
        [DataRow(AxiA6RelicLink)]
        [DataRow(CompanionRivenModVeiledLink)]
        public void Test2ItemInformationAsync(string value)
        {
            var itemResult = GetItemInformation(value);
            Assert.IsTrue(itemResult.IsSuccess);
        }

        [TestMethod("3. Getting All Items")]
        public void Test3GetAllItemsAsync()
        {
            var itemsResult = GetAllItems();
            Assert.IsTrue(itemsResult.IsSuccess);
            Assert.IsTrue(itemsResult.Result.Info.Items.Length > 0);
        }

        [TestMethod("4. Getting Orders For Item")]
        [DataRow(AshPrimeSetLink)]
        [DataRow(GladiatorMightModLink)]
        [DataRow(AxiA6RelicLink)]
        [DataRow(CompanionRivenModVeiledLink)]
        public void Test4GettingOrdersForItem(string value)
        {
            var itemOrdersResult = GetItemOrders(value);
            Assert.IsTrue(itemOrdersResult.IsSuccess);
            Assert.IsTrue(itemOrdersResult.Result.Info.Orders.Length > 0);
        }

        [TestMethod("5. Create Order on profile")]
        [DataRow(LegendaryFusionCoreLink)]
        public void Test5CreateOrder(string value)
        {
            var itemInformationResult = GetItemInformation(value);
            Assert.IsTrue(itemInformationResult.IsSuccess);

            var orderResult = CreateOrder(new CreateOrderRequest
            {
                ItemId = itemInformationResult.Result.Info.Item.Id,
                OrderType = Market_Api.JsonData.Enums.OrderType.Sell,
                Platinum = 1000,
                Quantity = 1,
                Visible = false
            });

            Assert.IsTrue(orderResult.IsSuccess);
        }


        [TestMethod("6. Recieving Orders on profile")]
        public void Test6MyProfileOrdersAsync()
        {
            var orderResult = GetProfileOrders();
            Assert.IsTrue(orderResult.IsSuccess);
            Assert.IsTrue(orderResult.Result.Info.SellOrders.Length > 0);
            var fusionCoreItems = orderResult.Result.Info.SellOrders.Where(p => p.Item.UrlName == LegendaryFusionCoreLink).ToArray();
            Assert.IsTrue(fusionCoreItems.Length > 0);
            var selectedFusionCoreItem = fusionCoreItems.Where(p => p.Visible == false && p.Platinum == 1000 && p.Quantity == 1).FirstOrDefault();
            Assert.IsTrue(selectedFusionCoreItem != null);
        }


        [TestMethod("7. Upgrade Order on profile")]
        [DataRow(LegendaryFusionCoreLink)]
        public void Test7UpgradeOrder(string value)
        {
            var orderResult = GetProfileOrders();
            Assert.IsTrue(orderResult.IsSuccess);

            var legendaryFusionCoreItemOrder = orderResult.Result.Info.SellOrders.Where(p => p.Item.UrlName == value).First();
            var endPrice = legendaryFusionCoreItemOrder.Platinum == 1000 ? 1001 : 1000;

            var updateResult = UpdateOrder(new UpdateOrderRequest
            {
                OrderID = legendaryFusionCoreItemOrder.Id,
                Platinum = endPrice,
                Quantity = 1,
                Visible = false
            });

            Assert.IsTrue(updateResult.IsSuccess);
        }

        [TestMethod("8. Delete Order on profile")]
        [DataRow(LegendaryFusionCoreLink)]
        public void Test8DeleteOrder(string value)
        {
            var orderResult = GetProfileOrders();
            Assert.IsTrue(orderResult.IsSuccess);

            var legendaryFusionCoreItemOrder = orderResult.Result.Info.SellOrders.Where(p => p.Item.UrlName == value).First();
            var deleteResult = DeleteOrder(legendaryFusionCoreItemOrder.Id);

            Assert.IsTrue(deleteResult.IsSuccess);
        }

        [TestMethod("9. Logout Request")]
        public void Test9LogoutAsync()
        {
            var logoutResult = LogOut();
            Assert.IsTrue(logoutResult.IsSuccess);
        }

        private RequestResult<LoginResponse> LogIn()
            => AsyncHelpers.RunSync(() => _client.LogInAsync(new LoginRequest
            {
                AuthType = Market_Api.JsonData.Enums.AuthType.Cookie,
                Email = LoginData.UserName,
                Password = LoginData.Password
            }));

        private RequestResult<LogoutResponse> LogOut()
            => AsyncHelpers.RunSync(() => _client.LogOutAsync());

        private RequestResult<ProfileOrders> GetProfileOrders(string profileName = null)
            => AsyncHelpers.RunSync(() => _client.GetProfileOrdersAsync(profileName));

        private RequestResult<ItemInformation> GetItemInformation(string itemUrl)
            => AsyncHelpers.RunSync(() => _client.GetItemInformationAsync(itemUrl));

        private RequestResult<Items> GetAllItems()
            => AsyncHelpers.RunSync(() => _client.GetAllItemsAsync());

        private RequestResult<Orders> GetItemOrders(string itemUrl)
            => AsyncHelpers.RunSync(() => _client.GetItemOrdersAsync(itemUrl));

        private RequestResult<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrder)
            => AsyncHelpers.RunSync(() => _client.CreateOrderAsync(createOrder));

        private RequestResult<ProfileOrders> UpdateOrder(UpdateOrderRequest updatedOrder)
            => AsyncHelpers.RunSync(() => _client.UpdateOrderAsync(updatedOrder));

        private RequestResult<DeleteOrderResponse> DeleteOrder(string OrderID)
            => AsyncHelpers.RunSync(() => _client.DeleteOrderAsync(OrderID));
    }
}
