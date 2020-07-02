using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicaret.Services.Services.Interfaces;
using ETicaret.Common.DTO;

namespace ETicaret.Web.Hubs
{
    public class SearchHub : BaseHub
    {
       
        public async Task GetSearch(string value)
        {
            var products = GetApiResult<IEnumerable<ProductModel>>("/product/count/" + value);

            await Clients.All.SendAsync("NewContainer");

            foreach (var pm in products)
            {
                await Clients.All.SendAsync("ReceiveSearch", pm.Id, pm.Price, pm.ProductName, pm.ProductPicture, pm.CategoryName);
            }
            
        }

    }
}
