using System;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_Api.Api.Data;
using Warframe.Market_Api.JsonData.Content;

namespace Warframe.Market_Api.Api.Clients.Implementation
{
    public class ApiClient : IApiClient
    {
        private BaseHttpClient _baseHttpClient;

        public ApiClient()
        {
            _baseHttpClient = new BaseHttpClient();
        }

        public RequestResult<Order> CreateOrder(string itemUrl, short quanitity, short price)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RequestResult<ProfileOrders>> UpdateOrder(UpdateOrder updatedOrder)
        {
            try
            {
                return RequestResult<ProfileOrders>.Success(await _baseHttpClient.PutAsync<UpdateOrder, ProfileOrders>(
                    EndPoints.GetProfileOrderUrl(updatedOrder.OrderID), 
                    updatedOrder));
            }
            catch (Exception exception)
            {
                return RequestResult<ProfileOrders>.Error(exception);
            }
        }

        public async Task<RequestResult<DeleteOrderResponse>> DeleteOrder(string OrderID)
        {
            try
            {
                return RequestResult<DeleteOrderResponse>.Success(await _baseHttpClient.DeleteAsync<DeleteOrderResponse>(EndPoints.GetProfileOrderUrl(OrderID)));
            }
            catch (Exception exception)
            {
                return RequestResult<DeleteOrderResponse>.Error(exception);
            }
        }

        public async Task<RequestResult<Items>> GetAllItemsAsync()
        {
            try
            {
                return RequestResult<Items>.Success(await _baseHttpClient.GetAsync<Items>(EndPoints.GetAllItemsUrl()));
            }
            catch(Exception exception)
            {
                return RequestResult<Items>.Error(exception);
            }
        }

        public async Task<RequestResult<ItemInformation>> GetItemInformationAsync(string itemUrl)
        {
            try
            {
                return RequestResult<ItemInformation>.Success(await _baseHttpClient.GetAsync<ItemInformation>(EndPoints.GetItemInformationUrl(itemUrl)));
            }
            catch (Exception exception)
            {
                return RequestResult<ItemInformation>.Error(exception);
            }
        }

        public async Task<RequestResult<Orders>> GetItemOrders(string itemUrl)
        {
            try
            {
                return RequestResult<Orders>.Success(await _baseHttpClient.GetAsync<Orders>(EndPoints.GetItemOrdersUrl(itemUrl)));
            }
            catch (Exception exception)
            {
                return RequestResult<Orders>.Error(exception);
            }
        }

        public async Task<RequestResult<ProfileOrders>> GetProfileOrdersAsync(string profileName = null)
        {
            try
            {
                return RequestResult<ProfileOrders>.Success(await _baseHttpClient.GetAsync<ProfileOrders>(EndPoints.GetProfileOrdersUrl(profileName)));
            }
            catch (Exception exception)
            {
                return RequestResult<ProfileOrders>.Error(exception);
            }
        }

        public async Task<RequestResult<LoginResponse>> LogInAsync(string email, string password)
        {
            try
            {
                return RequestResult<LoginResponse>.Success(await _baseHttpClient.PostAsync<Login, LoginResponse>(
                       EndPoints.GetLoginUrl(),
                       new Login
                       {
                           AuthType = JsonData.Enums.AuthType.Cookie,
                           Email = email,
                           Password = password
                       }));
            }
            catch (Exception exception)
            {
                return RequestResult<LoginResponse>.Error(exception);
            }
        }

        public async Task<RequestResult<LogoutResponse>> LogOutAsync()
        {
            try
            {
                return RequestResult<LogoutResponse>.Success(await _baseHttpClient.GetAsync<LogoutResponse>(EndPoints.GetLogoutUrl()));
            }
            catch (Exception exception)
            {
                return RequestResult<LogoutResponse>.Error(exception);
            }
        }
    }
}
