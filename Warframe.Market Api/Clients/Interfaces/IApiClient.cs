using System.Threading.Tasks;
using Warframe.Market_Api.Api.Data;
using Warframe.Market_Api.JsonData.Content;

namespace Warframe.Market_Api.Api.Clients.Interfaces
{
    public interface IApiClient
    {
        Task<RequestResult<LoginResponse>> LogInAsync(string email, string password);
        Task<RequestResult<LogoutResponse>> LogOutAsync();

        Task<RequestResult<Items>> GetAllItemsAsync();
        Task<RequestResult<ItemInformation>> GetItemInformationAsync(string itemUrl);
        Task<RequestResult<Orders>> GetItemOrders(string itemUrl);

        Task<RequestResult<ProfileOrders>> GetProfileOrdersAsync(string profileName = null);
        RequestResult<Order> CreateOrder(string itemUrl, short quanitity, short price);
        Task<RequestResult<ProfileOrders>> UpdateOrder(UpdateOrder updatedOrder);
        Task<RequestResult<DeleteOrderResponse>> DeleteOrder(string OrderID);
    }
}
