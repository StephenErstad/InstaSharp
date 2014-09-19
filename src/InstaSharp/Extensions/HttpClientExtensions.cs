using System.Collections.Generic;
using System.Linq;
using InstaSharp.Infrastructure;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InstaSharp.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            string resultData = await response.Content.ReadAsStringAsync();

            var rateLimitRemaining = new List<string>().AsEnumerable();
            var rateLimitLimit = new List<string>().AsEnumerable();
            if (response.Headers.TryGetValues(@"X-Ratelimit-Remaining", out rateLimitRemaining))
            {
                JObject jsonResult = JObject.Parse(resultData);
                jsonResult["meta"]["rateLimitRemaining"] = rateLimitRemaining.FirstOrDefault();
                jsonResult["meta"]["rateLimitLimit"] = response.Headers.TryGetValues(@"X-Ratelimit-Limit", out rateLimitLimit) ? rateLimitLimit.FirstOrDefault() : "5000";
                resultData = jsonResult.ToString();
            }

            return JsonConvert.DeserializeObject<T>(resultData, new MediaConverter());
        }
    }
}
