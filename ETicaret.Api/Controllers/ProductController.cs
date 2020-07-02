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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productservice)
        {
            productService = productservice;
        }

        [HttpGet("/product/getall")]
        public IEnumerable<ProductModel> GetAll()
        {
            return productService.GetProductDetails();
        }
        [HttpGet("/product/get/{productId}")]
        public ProductModel Get(int productId)
        {
            return productService.GetProduct(productId);
        }

        [HttpGet("/product/myproducts/{userId}")]
        public IEnumerable<ProductModel> MyProducts(int userid)
        {
            return productService.SupplierProductDetails(userid);
        }


        [HttpGet("/product/search/{value}")]
        public IEnumerable<ProductModel> Search(string value) 
        {          
            return productService.GetProductsByCategories(value);
        }
        [HttpGet("/product/deleteproduct/{productId}&{userId}")]
        public bool DeleteProduct(int productId,int userId) 
        {
            return productService.Delete(productId, userId);
        }

        // POST api/values
        [HttpPost("/product/addproduct")]
        public bool AddProduct(ProductModel model)
        {
            return productService.Add(model, model.Id);
        }
    }
}