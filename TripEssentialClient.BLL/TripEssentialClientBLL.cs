using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TripEssentialClient.BLL.DataContract;

namespace TripEssentialClient.BLL
{
    public class TripEssentialClientBLL
    {
        private static MediaTypeWithQualityHeaderValue MediaTypeWithQualityHeaderValue
        {
            get
            {
                return new MediaTypeWithQualityHeaderValue("application/json");
            }
        }

        private static string TripEssentialAPIBaseAddress { get; set; }

        private static IHttpClientFactory HttpClientFactory { get; set; }

        public static void InitializeAppSettings(IConfiguration configuration)
        {
            try
            {
                TripEssentialAPIBaseAddress ??= configuration["AppSettings:Urls:TripEssentialAPIBaseAddress"];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InitializeHttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            try
            {
                HttpClientFactory ??= httpClientFactory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConstructClientError(ApiErrorResp apiErrorResp)
        {
            try
            {
                int _counter = apiErrorResp.Errors.Count();
                string _errorMessage = "\n";

                foreach (string error in apiErrorResp.Errors)
                {
                    if (_counter > 1)
                        _errorMessage += $"→ {error}.\n";
                    else
                        _errorMessage += $"{error}.\n";
                }

                return _errorMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static HttpClient CreateHttpGraphQLClient()
        {
            try
            {
                HttpClient _httpGraphQLClient = HttpClientFactory.CreateClient();
                _httpGraphQLClient.BaseAddress = new Uri(TripEssentialAPIBaseAddress);
                _httpGraphQLClient.Timeout = TimeSpan.FromMilliseconds(-1);
                _httpGraphQLClient.DefaultRequestHeaders.Clear();
                _httpGraphQLClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue);

                return _httpGraphQLClient;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static class TripItemHelper
        {
            public static async Task<List<TripItemResp>> GetTripItems()
            {
                try
                {
                    using HttpResponseMessage _httpResponseMessage = await CreateHttpGraphQLClient().GetAsync("api/TripItem/V1/GetTripItems");
                    if (!_httpResponseMessage.IsSuccessStatusCode)
                        throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

                    return await _httpResponseMessage.Content.ReadAsAsync<List<TripItemResp>>();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task<List<TripItemResp>> GetKnapsacktems()
            {
                try
                {
                    using HttpResponseMessage _httpResponseMessage = await CreateHttpGraphQLClient().GetAsync("api/TripItem/V1/GetKnapsacktems");
                    if (!_httpResponseMessage.IsSuccessStatusCode)
                        throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

                    return await _httpResponseMessage.Content.ReadAsAsync<List<TripItemResp>>();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task<decimal> GetKnapsackCapacity()
            {
                try
                {
                    using HttpResponseMessage _httpResponseMessage = await CreateHttpGraphQLClient().GetAsync("api/TripItem/V1/GetKnapsackCapacity");
                    if (!_httpResponseMessage.IsSuccessStatusCode)
                        throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

                    return await _httpResponseMessage.Content.ReadAsAsync<decimal>();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task AddOrRemoveKnapsackItem(AddOrRemoveKnapsackItemReq addOrRemoveKnapsackItemReq)
            {
                try
                {
                    using HttpResponseMessage _httpResponseMessage = await CreateHttpGraphQLClient().PostAsJsonAsync("api/TripItem/V1/AddOrRemoveKnapsackItem", addOrRemoveKnapsackItemReq);
                    if (!_httpResponseMessage.IsSuccessStatusCode)
                        throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
