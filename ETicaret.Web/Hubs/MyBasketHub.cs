using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicaret.Services.Services.Interfaces;
using ETicaret.Common.DTO;

namespace ETicaret.Web.Hubs
{
    public class MyBasketHub : BaseHub
    {
       
        public async Task BuyProducts(string userid, string list)
        {
            List<int> products = new List<int>();

            while (list.Contains("-"))
            {
                string value = list.Substring(0, list.IndexOf("-"));
                products.Add(Convert.ToInt32(value));
                list = list.Substring(list.IndexOf("-") + 1);
            }

            
            await Clients.All.SendAsync("BuySuccess");
        }
        public async Task RemoveProduct(string productId, string userId)
        {
            bool ctr = GetApiResult<bool>("/basket/removeproduct/" + productId + "&" + userId);

            int productCount = GetApiResult<int>("/basket/count/" + userId);

            await Clients.All.SendAsync("FixTheMyBasketArea", productCount);
        }
    }
}
