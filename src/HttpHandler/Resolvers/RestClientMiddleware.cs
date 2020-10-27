using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using HttpHandler.Headers;
using System.Text;

namespace HttpHandler.Resolvers
{
    public static class RestClientMiddleware
    {

        //public static async Task<TBody> GetData<TBody>(string url, List<HeaderParameterStructure> headers)
        public static async Task<TBodyResponse> GetData<TBodyResponse>(string baseUrl, string endpoint, HeaderParameters headers)
        {
            TBodyResponse BodyResult;
            var _uri = new Uri(baseUrl);
            using (var httpClient = new HttpClient { BaseAddress = _uri })
            {
                if(!(headers.AuthHeader is null))
                    httpClient.DefaultRequestHeaders.Authorization = headers.AuthHeader;

                headers.HeaderList.ForEach(x => httpClient.DefaultRequestHeaders.Add(x.Name, x.Value));
                
                using (var _response = await httpClient.GetAsync(endpoint))
                {
                    string responseData = await _response.Content.ReadAsStringAsync();
                    BodyResult = JsonConvert.DeserializeObject<TBodyResponse>(responseData);
                }
            }

            return BodyResult;
        }


        public static async Task<TBodyResponse> GetPost<TBodyResponse, TBodyRequest>
            (TBodyRequest BodyRequest, string baseUrl, string endpoint, HeaderParameters headers)
        {
            TBodyResponse BodyResult;
            var _uri = new Uri(baseUrl);
            using (var httpClient = new HttpClient { BaseAddress = _uri })
            {
                if (!(headers.AuthHeader is null))
                    httpClient.DefaultRequestHeaders.Authorization = headers.AuthHeader;

                headers.HeaderList.ForEach(x => httpClient.DefaultRequestHeaders.Add(x.Name, x.Value));
                var content = SetHttpContent(BodyRequest);
                using (var _response = await httpClient.PostAsync(endpoint, content))
                {
                    string responseData = await _response.Content.ReadAsStringAsync();
                    BodyResult = JsonConvert.DeserializeObject<TBodyResponse>(responseData);
                }
            }

            return BodyResult;
        }

        private static HttpContent SetHttpContent<TBodyRequest>(TBodyRequest BodyRequest)
        {
            var payload = JsonConvert.SerializeObject(BodyRequest);
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            return content;
        }
    }
}