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
    public class UserController : ControllerBase
    {
      /*  IHubContext<NotifyHub> _hub;
        public UserController(IHubContext<NotifyHub> hub)
        {
            _hub = hub;
        }*/
        private readonly IUserService UserService;
        public UserController(IUserService src)
        {
            UserService = src;
        }

        [HttpGet("/user/getall")]
        public IEnumerable<UserModel> GetAll()
        {
           // _hub.Clients.All.SendAsync("updated");
            return UserService.GetUsers();
        }

        [HttpGet("/user/get/{userId}")]
        public UserModel Get(int userId)
        {  
            return UserService.GetUser(userId);
        }

        [HttpGet("/user/getid/{email}&{password}")]
        public int GetId(string email, string password)
        {
            return UserService.GetUserId(email, password);
        }

        [HttpPost("/user/useradd")]
        public bool UserAdd(UserModel user)
        {
            return UserService.Add(user);
        }

    }
}