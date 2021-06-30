using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_Api.Api.Data;
using Warframe.Market_Api.JsonData.Content;

namespace Warframe.Market_Api.Api.Clients.Implementation
{
    public class ApiClient : IApiClient
    {
        private BaseHttpClient _baseHttpClient;
        private Dictionary<string, string> _headerDictionary;

        public ApiClient()
        {
            _headerDictionary = new Dictionary<string, string>();
            _headerDictionary.Add("User-Agent", "georg.kapp@gmx.at Warframe.Market API Client");
            _headerDictionary.Add("Authorization", "JWT");
            _headerDictionary.Add("language", "en");
            _headerDictionary.Add("accept", "application/json");
            _headerDictionary.Add("platform", "pc");
            _headerDictionary.Add("auth_type", "cookie");

            _baseHttpClient = new BaseHttpClient(_headerDictionary);
        }

        #region Login/Logout
        public async Task<RequestResult<LoginResponse>> LogInAsync(LoginRequest loginRequest)
        {
            try
            {
                return RequestResult<LoginResponse>.Success(
                    await _baseHttpClient.PostAsync<LoginRequest, LoginResponse>(
                       EndPoints.GetLoginUrl(), loginRequest));
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
                return RequestResult<LogoutResponse>.Success(
                    await _baseHttpClient.GetAsync<LogoutResponse>(
                        EndPoints.GetLogoutUrl()));
            }
            catch (Exception exception)
            {
                return RequestResult<LogoutResponse>.Error(exception);
            }
        }

        #endregion

        #region Get Information
        public async Task<RequestResult<ProfileOrders>> GetProfileOrdersAsync(string profileName = null)
        {
            try
            {
                return RequestResult<ProfileOrders>.Success(
                    await _baseHttpClient.GetAsync<ProfileOrders>(
                        EndPoints.GetProfileOrdersUrl(profileName)));
            }
            catch (Exception exception)
            {
                return RequestResult<ProfileOrders>.Error(exception);
            }
        }

        public async Task<RequestResult<ItemInformation>> GetItemInformationAsync(string itemUrl)
        {
            try
            {
                return RequestResult<ItemInformation>.Success(
                    await _baseHttpClient.GetAsync<ItemInformation>(
                        EndPoints.GetItemInformationUrl(itemUrl)));
            }
            catch (Exception exception)
            {
                return RequestResult<ItemInformation>.Error(exception);
            }
        }

        public async Task<RequestResult<Items>> GetAllItemsAsync()
        {
            try
            {
                return RequestResult<Items>.Success(
                    await _baseHttpClient.GetAsync<Items>(
                        EndPoints.GetAllItemsUrl()));
            }
            catch(Exception exception)
            {
                return RequestResult<Items>.Error(exception);
            }
        }

        public async Task<RequestResult<Orders>> GetItemOrdersAsync(string itemUrl)
        {
            try
            {
                return RequestResult<Orders>.Success(
                    await _baseHttpClient.GetAsync<Orders>(
                        EndPoints.GetItemOrdersUrl(itemUrl)));
            }
            catch (Exception exception)
            {
                return RequestResult<Orders>.Error(exception);
            }
        }
        #endregion

        #region Order Requests
        public async Task<RequestResult<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest createOrder)
        {
            try
            {
                return RequestResult<CreateOrderResponse>.Success(
                    await _baseHttpClient.PostAsync<CreateOrderRequest, CreateOrderResponse>(
                        EndPoints.GetProfileOrderUrl(), createOrder));
            }
            catch (Exception exception)
            {
                return RequestResult<CreateOrderResponse>.Error(exception);
            }
        }

        public async Task<RequestResult<ProfileOrders>> UpdateOrderAsync(UpdateOrderRequest updatedOrder)
        {
            try
            {
                return RequestResult<ProfileOrders>.Success(
                    await _baseHttpClient.PutAsync<UpdateOrderRequest, ProfileOrders>(
                        EndPoints.GetProfileOrderUrlByID(updatedOrder.OrderID), updatedOrder));
            }
            catch (Exception exception)
            {
                return RequestResult<ProfileOrders>.Error(exception);
            }
        }

        public async Task<RequestResult<DeleteOrderResponse>> DeleteOrderAsync(string OrderID)
        {
            try
            {
                return RequestResult<DeleteOrderResponse>.Success(
                    await _baseHttpClient.DeleteAsync<DeleteOrderResponse>(
                        EndPoints.GetProfileOrderUrlByID(OrderID)));
            }
            catch (Exception exception)
            {
                return RequestResult<DeleteOrderResponse>.Error(exception);
            }
        }
        #endregion
    }
}
