using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ETicaret.Services.Services.Interfaces;
using ETicaret.Common.DTO;
using System;
using System.Collections.Generic;

namespace ETicaret.Web.Hubs
{
    public class HomeWithUserHub : BaseHub
    {
              
        public async Task AddProduct(string productId, string userId)
        {
            bool ctr = GetApiResult<bool>("/basket/addproduct/" + productId + "&" + userId);
            
            int productCount = GetApiResult<int>("/basket/count/" + userId);

            await Clients.All.SendAsync("FixTheMyBasketArea", productCount);
        }
        public async Task RemoveProduct(string productId, string userId)
        {
            bool ctr = GetApiResult<bool>("/basket/removeproduct/" + productId + "&" + userId);
            
            int productCount = GetApiResult<int>("/basket/count/" + userId);

            await Clients.All.SendAsync("FixTheMyBasketArea", productCount);
        }
        public void DeleteProduct(string productId, string userId)
        {
            bool ctr = GetApiResult<bool>("/product/deleteproduct/" + productId + "&" + userId);

        }

        public async Task GetSearch(string value)
        {
            var products = GetApiResult<IEnumerable<ProductModel>>("/product/search/" + value);

            await Clients.All.SendAsync("NewContainer");

            foreach (var pm in products)
            {
                await Clients.All.SendAsync("ReceiveSearch", pm.Id, pm.Price, pm.ProductName, pm.ProductPicture, pm.CategoryName);
            }

        }
        public async Task SearchItem(string list)
        {
            List<ProductModel> products = new List<ProductModel>();

            while (list.Contains("-"))
            {
                string value = list.Substring(0, list.IndexOf("-"));
                products.AddRange(GetApiResult<IEnumerable<ProductModel>>("/product/search/" + value));
                list = list.Substring(list.IndexOf("-") + 1);
            }

            await Clients.All.SendAsync("NewContainer");

            foreach (var pm in products)
            {
                await Clients.All.SendAsync("ReceiveSearch", pm.Id, pm.Price, pm.ProductName, pm.ProductPicture, pm.CategoryName);
            }

        }
        public async Task AddressUpdate(string addressId, string country, string city, string district, string street, string door , string userid)
        {
            AddressModel address = new AddressModel();
            address.Country = country;
            address.City = city;
            address.District = district;
            address.Street = street;
            address.DoorNumber = door;

            bool ctr = PostApiResult<AddressModel>("/address/updateaddress/" + userid ,address);

            await Clients.All.SendAsync("InputSuccess");
        }
    }

}

