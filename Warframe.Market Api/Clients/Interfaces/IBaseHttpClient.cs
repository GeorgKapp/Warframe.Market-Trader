using System.Net.Http;
using System.Threading.Tasks;

namespace Warframe.Market_Api.Api.Clients.Interfaces
{
    internal interface IBaseHttpClient
    {
        /// <summary>
        /// Get Request that returns T Result
        /// </summary>
        /// <typeparam name="TResponse">the object that will be deserialized from the http result</typeparam>
        /// <param name="requestUrl">the url that will be used for the get request</param>
        /// <returns></returns>
        public Task<TResponse> GetAsync<TResponse>(string requestUrl)
           where TResponse : new();

        /// <summary>
        /// Delete Request that returns T Result
        /// </summary>
        /// <typeparam name="TResponse">>the object that will be deserialized from the http result</typeparam>
        /// <param name="requestUrl">the url that will be used for the delete request</param>
        /// <returns></returns>
        public Task<TResponse> DeleteAsync<TResponse>(string requestUrl)
            where TResponse : new();

        /// <summary>
        /// Post Request that returns TResponse Result based on the send TRequest type
        /// </summary>
        /// <typeparam name="TRequest">the object type that will be serialized for the post request body</typeparam>
        /// <typeparam name="TResponse">the object type that will be deserialized from the http result</typeparam>
        /// <param name="requestUrl">the url that will be used for the post request</param>
        /// <param name="requestContent">the object that will become the json body</param>
        /// <returns></returns>
        public Task<TResponse> PostAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new();

        /// <summary>
        /// Put Request that returns TResponse Result based on the send TRequest type
        /// </summary>
        /// <typeparam name="TRequest">the object type that will be serialized for the put request body</typeparam>
        /// <typeparam name="TResponse">the object type that will be deserialized from the http result</typeparam>
        /// <param name="requestUrl">the url that will be used for the put request</param>
        /// <param name="requestContent">the object that will become the json body</param>
        public Task<TResponse> PutAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new();
    }
}
