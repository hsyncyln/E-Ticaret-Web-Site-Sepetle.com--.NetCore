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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;
        public AddressController(IAddressService addressservice)
        {
            addressService = addressservice;
        }

        [HttpGet("/address/getaddress/{userId}")]
        public AddressModel GetAddress(int userId)
        {
            return addressService.GetAddressWithUniqueValue(userId);
        }

        [HttpPost("/address/updateaddress/{userId}")]
        public bool UpdateAddress(int userId, AddressModel address)
        {    
            addressService.UpdateAddress(userId, address);
            return true;
        }
    }
}