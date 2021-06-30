using System.Threading.Tasks;
using Warframe.Market_Api.Api.Data;
using Warframe.Market_Api.JsonData.Content;

namespace Warframe.Market_Api.Api.Clients.Interfaces
{
    public interface IApiClient
    {
        Task<RequestResult<LoginResponse>> LogInAsync(LoginRequest loginRequest);
        Task<RequestResult<LogoutResponse>> LogOutAsync();

        Task<RequestResult<ProfileOrders>> GetProfileOrdersAsync(string profileName = null);
        Task<RequestResult<ItemInformation>> GetItemInformationAsync(string itemUrl);
        Task<RequestResult<Items>> GetAllItemsAsync();
        Task<RequestResult<Orders>> GetItemOrdersAsync(string itemUrl);

        Task<RequestResult<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest createOrder);
        Task<RequestResult<ProfileOrders>> UpdateOrderAsync(UpdateOrderRequest updatedOrder);
        Task<RequestResult<DeleteOrderResponse>> DeleteOrderAsync(string OrderID);
    }
}
