using Brotli;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Warframe.Market_Api.Api.Clients.Interfaces;
using Warframe.Market_Api.Converter;

namespace Warframe.Market_Api.Api.Clients.Implementation
{
    internal class BaseHttpClient : IBaseHttpClient
    {
        private HttpClient _channel;
        private Dictionary<string, string> _headerDictionary;
        public BaseHttpClient()
        {
            _channel = new HttpClient();
            _headerDictionary = new Dictionary<string, string>();
        }

        public BaseHttpClient(Dictionary<string, string> headerDictionary)
        {
            _channel = new HttpClient();
            _headerDictionary = headerDictionary;
        }

        #region Send Methods

        public async Task<TResponse> GetAsync<TResponse>(string requestUrl) 
            where TResponse : new() 
            => await SendAsync<TResponse>(requestUrl, HttpMethod.Get);

        public async Task<TResponse> DeleteAsync<TResponse>(string requestUrl) 
            where TResponse : new()
            => await SendAsync<TResponse>(requestUrl, HttpMethod.Delete);

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new()
            => await SendAsync<TRequest, TResponse>(requestUrl, requestContent, HttpMethod.Post);

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new()
            => await SendAsync<TRequest, TResponse>(requestUrl, requestContent, HttpMethod.Put);

        private async Task<T> SendAsync<T>(string requestUrl, HttpMethod httpMethod)
            where T : new()
        {
            using (var responseContent = await SendRequestAsync(requestUrl, httpMethod))
            {
                return await GetResponseContentAsync<T>(responseContent);
            }
        }

        private async Task<TResponse> SendAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent, HttpMethod httpMethod)
            where TRequest : new()
            where TResponse : new()
        {
            var jsonString = JsonConverter.ToJson(requestContent);
            using (var responseContent = await SendRequestAsync(requestUrl, httpMethod, jsonString))
            {
                return await GetResponseContentAsync<TResponse>(responseContent);
            }
        }

        #endregion

        private async Task<T> GetResponseContentAsync<T>(HttpContent content)
            where T : new()
        {
            if (content is object && content.Headers.ContentType.MediaType == "application/json")
            {
                var encodingType = content.Headers.ContentType.CharSet?.ToLower();
                var compressionType = content.Headers.ContentEncoding.FirstOrDefault()?.ToLower();
                var contentBytes = await content.ReadAsByteArrayAsync();
                var decompressedBytes = await DecompressMessage(contentBytes, compressionType);
                var encodedString = EncodeMessage(decompressedBytes, encodingType);
                return JsonConverter.FromJson<T>(encodedString);
            }
            else
            {
                throw new Exception("HTTP Response was invalid and cannot be deserialised.");
            }
        }

        private static async Task<byte[]> DecompressMessage(byte[] content, string compressionType)
        {
            using (MemoryStream input = new MemoryStream(content))
            using (MemoryStream output = new MemoryStream())
            {
                switch (compressionType)
                {
                    case "br":
                        using (BrotliStream decompressor = new BrotliStream(input, CompressionMode.Decompress))
                        {
                            await decompressor.CopyToAsync(output);
                        }
                        break;
                    case "deflate":
                        using (DeflateStream decompressor = new DeflateStream(input, CompressionMode.Decompress))
                        {
                            await decompressor.CopyToAsync(output);
                        }
                        break;
                    case "gzip":
                        using (GZipStream decompressor = new GZipStream(input, CompressionMode.Decompress))
                        {
                            await decompressor.CopyToAsync(output);
                        }
                        break;
                    default:
                        return content;
                }
                return output.ToArray();
            }
        }

        private static string EncodeMessage(byte[] content, string encodingType)
        {
            switch (encodingType)
            {
                case "utf8":
                case "utf-8":
                    return Encoding.UTF8.GetString(content);
                default:
                    return new string(content.Select(b => (char)b).ToArray());
            }
        }

        private HttpRequestMessage ConfigureRequest(string url, HttpMethod method, HttpContent content = null)
        {
            return new HttpRequestMessage(method, url)
            {
                Content = content
            };
        }

        private async Task<HttpContent> SendRequestAsync(string url, HttpMethod method, string jsonString = null)
        {
            var request = !string.IsNullOrEmpty(jsonString) 
                ? ConfigureRequest(url, method, new StringContent(jsonString, Encoding.UTF8, "application/json"))
                : ConfigureRequest(url, method);

            foreach(var keyvaluePair in _headerDictionary)
                request.Headers.TryAddWithoutValidation(keyvaluePair.Key, keyvaluePair.Value);

            var response = await _channel.SendAsync(request);
            response.EnsureSuccessStatusCode();
            request.Dispose();
            return response.Content;
        }
    }
}
