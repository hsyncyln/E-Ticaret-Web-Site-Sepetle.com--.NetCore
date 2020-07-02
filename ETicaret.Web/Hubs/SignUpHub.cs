using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ETicaret.Services.Services.Interfaces;
using ETicaret.Common.DTO;

namespace ETicaret.Web.Hubs
{
    public class SignUpHub : BaseHub
    {
        
        public async Task UserAdd(string fname, string lname, string email, string password, string tel)
        {
            UserModel user = new UserModel();
            user.FirstName = fname;
            user.LastName = lname;
            user.EMail = email;
            user.Password = password;
            user.PhoneNumber = tel;

            bool request = PostApiResult<UserModel>("/user/useradd",user);

            await Clients.All.SendAsync("RequestControl",request);
        }
    }
}
