using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Implementation;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_Api.Api.Data;

namespace Warframe.Market_Api_Unit_Tests
{
    [TestClass]
    public class UnitTests
    {
        IApiClient _client;

        private const string AshPrimeSetLink = "ash_prime_set";
        private const string GladiatorMightModLink = "gladiator_might";
        private const string AxiA6RelicLink = "axi_n6_relic";
        private const string CompanionRivenModVeiledLink = "companion_weapon_riven_mod_(veiled)";
        private const string LegendaryFusionCoreLink = "legendary_fusion_core";

        public UnitTests()
        {
            _client = new ApiClient();
        }

        [TestMethod("Test Login Request")]
        public async Task TestLoginAsync()
        {
            var result = await _client.LogInAsync(LoginData.UserName, LoginData.Password);
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod("Test Logout Request")]
        public async Task TestLogoutAsync()
        {
            var loginResult = await _client.LogInAsync(LoginData.UserName, LoginData.Password);
            Assert.IsTrue(loginResult.IsSuccess);

            var logoutResult = await _client.LogOutAsync();
            Assert.IsTrue(logoutResult.IsSuccess);
        }

        [TestMethod("Test Recieving of own Profile Orders")]
        public async Task TestMyProfileOrdersAsync()
        {
            var loginResult = await _client.LogInAsync(LoginData.UserName, LoginData.Password);
            Assert.IsTrue(loginResult.IsSuccess);

            var orderResult = await _client.GetProfileOrdersAsync();
            Assert.IsTrue(orderResult.IsSuccess);
        }

        [TestMethod("Test Recieving of Item Information")]
        [DataRow(AshPrimeSetLink)]
        [DataRow(GladiatorMightModLink)]
        [DataRow(AxiA6RelicLink)]
        [DataRow(CompanionRivenModVeiledLink)]
        public async Task TestItemInformationAsync(string value)
        {
            var itemResult = await _client.GetItemInformationAsync(value);
            Assert.IsTrue(itemResult.IsSuccess);
        }

        [TestMethod("Test Getting All Items")]
        public async Task TestGetAllItemsAsync()
        {
            var itemsResult = await _client.GetAllItemsAsync();
            Assert.IsTrue(itemsResult.IsSuccess);
            Assert.IsTrue(itemsResult.Result.Info.Items.Length > 0);
        }

        [TestMethod("Test Getting Orders For Item")]
        [DataRow(AshPrimeSetLink)]
        [DataRow(GladiatorMightModLink)]
        [DataRow(AxiA6RelicLink)]
        [DataRow(CompanionRivenModVeiledLink)]
        public async Task TestGettingOrdersForItem(string value)
        {
            var itemOrdersResult = await _client.GetItemOrders(value);
            Assert.IsTrue(itemOrdersResult.IsSuccess);
            Assert.IsTrue(itemOrdersResult.Result.Info.Orders.Length > 0);
        }

        [TestMethod("Test Upgrade Order on profile")]
        [DataRow(LegendaryFusionCoreLink)]
        public async Task TestUpgradeOrder(string value)
        {
            var loginResult = await _client.LogInAsync(LoginData.UserName, LoginData.Password);
            Assert.IsTrue(loginResult.IsSuccess);

            var orderResult = await _client.GetProfileOrdersAsync();
            Assert.IsTrue(orderResult.IsSuccess);

            var legendaryFusionCoreItemOrder = orderResult.Result.Info.SellOrders.Where(p => p.Item.UrlName == value).First();
            var endPrice = legendaryFusionCoreItemOrder.Platinum == 1000 ? 1001 : 1000;

            var updateResult = await _client.UpdateOrder(new Market_Api.JsonData.Content.UpdateOrder
            {
                OrderID = legendaryFusionCoreItemOrder.Id,
                Platinum = endPrice,
                Quantity = 1,
                Visible = false
            });

            Assert.IsTrue(updateResult.IsSuccess);
        }

        [TestMethod("Test Delete Order on profile")]
        [DataRow(LegendaryFusionCoreLink)]
        public async Task TestDeleteOrder(string value)
        {
            var loginResult = await _client.LogInAsync(LoginData.UserName, LoginData.Password);
            Assert.IsTrue(loginResult.IsSuccess);

            var orderResult = await _client.GetProfileOrdersAsync();
            Assert.IsTrue(orderResult.IsSuccess);

            var legendaryFusionCoreItemOrder = orderResult.Result.Info.SellOrders.Where(p => p.Item.UrlName == value).First();
            var deleteResult = await _client.DeleteOrder(legendaryFusionCoreItemOrder.Id);

            Assert.IsTrue(deleteResult.IsSuccess);
        }
    }
}
