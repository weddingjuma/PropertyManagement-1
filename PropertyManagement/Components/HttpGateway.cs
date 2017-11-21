using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PropertyManagement.Components
{
    public class HttpGateway
    {
        public static async Task<Tresponse> Post<Trequest, Tresponse>(string url, Trequest requestData) where Tresponse : new()
        {
            using (var httpClient = new HttpClient())
            {
                return await Execute<Trequest, Tresponse>(url, requestData, httpClient, HttpMethod.Post);
            }
        }

        public static async Task<Tresponse> Post<Trequest, Tresponse>(string url, string authenticationHeaderValue, Trequest requestData) where Tresponse : new()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);
                return await Execute<Trequest, Tresponse>(url, requestData, httpClient, HttpMethod.Post);
            }
        }

        public static async Task<Tresponse> Get<Tresponse>(string url) where Tresponse : new()
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync(new Uri(url));
                return GetResponseObject<Tresponse>(responseMessage);
            }
        }

        public static async Task<Tresponse> Get<Tresponse>(string url, string authenticationHeaderValue) where Tresponse : new()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);
                var responseMessage = await httpClient.GetAsync(new Uri(url));
                return GetResponseObject<Tresponse>(responseMessage);
            }
        }

        public static async Task<Tresponse> Put<Trequest, Tresponse>(string url, string authenticationHeaderValue, Trequest requestData) where Tresponse : new()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationHeaderValue);
                return await Execute<Trequest, Tresponse>(url, requestData, httpClient, HttpMethod.Put);
            }
        }

        private static async Task<Tresponse> Execute<Trequest, Tresponse>(string url, Trequest requestData, HttpClient httpClient, HttpMethod httpMethod) where Tresponse : new()
        {
            var uri = new Uri(url);
            var json = JsonConvert.SerializeObject(requestData);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = httpMethod == HttpMethod.Put ? await httpClient.PutAsync(uri, requestContent) : await httpClient.PostAsync(uri, requestContent);
            return GetResponseObject<Tresponse>(responseMessage);
        }

        private static Tresponse GetResponseObject<Tresponse>(HttpResponseMessage responseMessage) where Tresponse : new()
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                try
                {
                    var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Tresponse>(responseString);
                }
                catch (Exception exception)
                {
                    return new Tresponse();
                }
            }
            else
            {
                return new Tresponse();
            }
        }
    }
}