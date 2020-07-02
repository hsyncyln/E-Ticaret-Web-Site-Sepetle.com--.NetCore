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
    public class BillController : ControllerBase
    {
        private readonly IBillService billService;
        public BillController(IBillService billservice)
        {
            billService = billservice;
        }

        // GET: api/Bill
    /*    [HttpGet]
        public IEnumerable<BillModel> Get()
        {
            return billService.
        }*/

        // GET: api/Bill/5
        [HttpGet("bill/get/{userId}")]
        public IEnumerable<ProductModel> Get(int userId)
        {
            return billService.MyBought(userId);
        }

        // POST: api/Bill
        [HttpPost("/bill/addbill")]
        public bool AddProduct(BillModel model)
        {
            return billService.AddBill(model);
        }

        // PUT: api/Bill/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
