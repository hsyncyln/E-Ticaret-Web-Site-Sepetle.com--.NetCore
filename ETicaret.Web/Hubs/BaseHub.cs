using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ETicaret.Web.Hubs
{
    public abstract class BaseHub : Hub
    {
        protected T GetApiResult<T>(string url)
        {

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("https://localhost:44344").Append(url);
            using (var client_ = new HttpClient())
            {
                var data = client_.GetStringAsync(urlBuilder_.ToString()).Result;

                var model = JsonConvert.DeserializeObject<T>(data);
                return model;
            }
        }

        protected bool PostApiResult<T>(string url, T model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44344");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync(url, model).Result;

            return response.IsSuccessStatusCode;

        }
    }
}
