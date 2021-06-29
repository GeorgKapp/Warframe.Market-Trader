using System.Threading.Tasks;

namespace Warframe.Market_Api.Api.Clients.Interfaces
{
    public interface IBaseHttpClient
    {
        /// <summary>
        /// Get Request that returns T Result
        /// </summary>
        /// <typeparam name="T">>the object that will be deserialized from the http resul</typeparam>
        /// <param name="requestUrl">the url that will be used for the get request</param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string requestUrl) 
            where T : new();

        /// <summary>
        /// Delete Request that returns T Result
        /// </summary>
        /// <typeparam name="T">>the object that will be deserialized from the http resul</typeparam>
        /// <param name="requestUrl">the url that will be used for the get request</param>
        /// <returns></returns>
        public Task<T> DeleteAsync<T>(string requestUrl)
            where T : new();

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
        /// <typeparam name="TRequest">the object type that will be serialized for the post request body</typeparam>
        /// <typeparam name="TResponse">the object type that will be deserialized from the http result</typeparam>
        /// <param name="requestUrl">the url that will be used for the post request</param>
        /// <param name="requestContent">the object that will become the json body</param>
        /// <returns></returns>
        public Task<TResponse> PutAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new();

        /// <summary>
        /// Post Request that returns no result eg.: Login only IsSuccess is needed
        /// </summary>
        /// <typeparam name="T">the object type that will be serialized for the post request body</typeparam>
        /// <param name="requestUrl">the url that will be used for the post request</param>
        /// <param name="requestContent">the object that will become the json body</param>
        /// <returns></returns>
        public Task PostAsync<T>(string requestUrl, T requestContent)
            where T : new();
    }
}
