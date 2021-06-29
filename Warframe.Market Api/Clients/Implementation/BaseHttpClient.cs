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

            _headerDictionary.Add("User-Agent", "georg.kapp@gmx.at Warframe.Market API Client");
            _headerDictionary.Add("Authorization", "JWT");
            _headerDictionary.Add("language", "en");
            _headerDictionary.Add("accept", "application/json");
            _headerDictionary.Add("platform", "pc");
            _headerDictionary.Add("auth_type", "cookie");
        }

        #region Send Methods

        public async Task<T> GetAsync<T>(string requestUrl)
            where T : new()
        {
            using (var responseContent = await SendRequestAsync(requestUrl, HttpMethod.Get))
            {
                return await GetResponseContentAsync<T>(responseContent);
            }
        }

        public async Task<T> DeleteAsync<T>(string requestUrl)
            where T : new()
        {
            using (var responseContent = await SendRequestAsync(requestUrl, HttpMethod.Delete))
            {
                return await GetResponseContentAsync<T>(responseContent);
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new()
        {
            var jsonString = JsonConverter.ToJson(requestContent);
            using (var responseContent = await SendRequestAsync(requestUrl, HttpMethod.Post, jsonString))
            {
                return await GetResponseContentAsync<TResponse>(responseContent);
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUrl, TRequest requestContent)
            where TRequest : new()
            where TResponse : new()
        {
            var jsonString = JsonConverter.ToJson(requestContent);
            using (var responseContent = await SendRequestAsync(requestUrl, HttpMethod.Put, jsonString))
            {
                return await GetResponseContentAsync<TResponse>(responseContent);
            }
        }

        public async Task PostAsync<T>(string requestUrl, T requestContent)
            where T : new()
        {
            var jsonString = JsonConverter.ToJson(requestContent);
            (await SendRequestAsync(requestUrl, HttpMethod.Post, jsonString)).Dispose();
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
