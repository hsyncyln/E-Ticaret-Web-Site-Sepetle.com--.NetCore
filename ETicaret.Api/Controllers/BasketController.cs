using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Common.DTO;
using ETicaret.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketservice)
        {
            basketService = basketservice;
        }

        [HttpGet("/basket/getproducts/{userId}")]
        public IEnumerable<ProductModel> GetProducts(int userId)
        {
            return basketService.GetProductsInBasket(userId);
        }

        [HttpGet("/basket/addproduct/{productId}&{userId}")]
        public bool AddProducts(int productId,int userId)
        {
            basketService.AddProductToMyBasket(productId, userId);
            return true;
        }

        [HttpGet("/basket/removeproduct/{productId}&{userId}")]
        public bool RemoveProducts(int productId,int userId)
        {
            basketService.RemoveProductToMyBasket(productId, userId);
            return true;
        }

        [HttpGet("/basket/count/{userId}")]
        public int Count(int userId)
        {
            return basketService.ProductCountInMyBasket(Convert.ToInt32(userId));
        }


    }
}