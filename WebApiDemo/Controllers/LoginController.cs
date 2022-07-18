using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using WebApiDemo.Core;
using WebApiDemo.Dal;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Get(string userNo, string password)
        {
            UserDal userDal = new UserDal();
            User? user = userDal.GetUserByUserNoAndPassword(userNo, password);
            return user != null ? "Login successed!" : "Login Failed";
        }
        
        [HttpPost]
        public int Insert(string userNo, string userName, int userLevel, string password)
        {
            UserDal userDal = new UserDal();
            User user = new User();
            user.UserNo = userNo;
            user.UserName = userName;
            user.UserLevel = userLevel;
            user.Password = password;
            return userDal.AddUser(user);
        }

        [HttpPut]
        public int Update(int id, string userNo, string userName, int userLevel, string password)
        {
            UserDal userDal = new UserDal();
            User user = new User();
            user.Id = id;
            user.UserNo = userNo;
            user.UserName = userName;
            user.UserLevel = userLevel;
            user.Password = password;
            return userDal.UpdateUser(user);
        }

        [HttpDelete]
        public int Remove(int id)
        {
            UserDal userDal = new UserDal();
            return userDal.RemoveUserById(id);
        }
    }
}
