using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PaceWisdomAssignment.Models
{
    public static class StaticInstances
    {
        public static HttpClient ApiClient = new HttpClient();
        public static string baseUrl = ConfigurationManager.AppSettings.Get("FlickerApi");
        public static string cbm = ConfigurationManager.AppSettings.Get("cbm");
        static StaticInstances()
        {
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static T GetDataAsyncModel<T>(string path)
        {
            T data = default;
            var resTask = ApiClient.GetAsync(baseUrl + path);
            resTask.Wait();
            var response = resTask.Result;
            using (HttpContent cont = response.Content)
            {
                Task<string> result = cont.ReadAsStringAsync();
                var _res = result.Result;
                int cbml = cbm.Length + 1;
                _res = _res.Substring(cbml, _res.Length - cbml - 1);
                data = JsonConvert.DeserializeObject<T>(_res);
            }
            return data;
        }
        public static async Task<IEnumerable<T>> GetDataAsync<T>(string path)
        {
            IEnumerable<T> user = null;
            var response = ApiClient.GetAsync(baseUrl + path).Result;
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<IEnumerable<T>>();
            }
            return user;
        }
        public static string GetStringAsync(string path)
        {
            var _res = "";
            var response = ApiClient.GetAsync(baseUrl + path).Result;
            using(HttpContent cont = response.Content)
            {
                Task<string> result = cont.ReadAsStringAsync();
                _res = result.Result;
            }
            return _res;
        }
    }
}