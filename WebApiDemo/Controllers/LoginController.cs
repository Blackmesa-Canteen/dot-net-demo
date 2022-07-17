using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using WebApiDemo.Core;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Get(string userNo, string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = sqlHelper.ExecuteTable("SELECT * FROM User");
            DataRow dataRow = null;
            if (res.Rows.Count > 0)
            {
                dataRow = res.Rows[0];
            }

            if (dataRow == null)
            {
                return "Login Failed"; 
            }
            
            var resUserNo = dataRow["UserNo"].ToString();
            var resPassword = dataRow["Password"].ToString();
            if (resUserNo == userNo && resPassword == password)
            {
                return "Login successed!";
            }
            else
            {
                return "Login Failed";
            }
            
        }
        
        [HttpPost]
        public string Insert(string userNo, string userName, int userLevel, string password)
        {
            SqlHelper sqlHelper = new SqlHelper();

            sqlHelper.ExecuteNonQuery(
                "INSERT INTO User (UserNo, UserName, UserLevel, Password) VALUES('@UserNo','@UserName', '@UserLevel', '@Password')",
                new MySqlParameter("@UserNo", userNo),
                new MySqlParameter("@UserName", userName),
                new MySqlParameter("@UserLevel", userLevel),
                new MySqlParameter("@Password", password)
                );

            return "done";
        }

        [HttpPut]
        public string Update()
        {
            SqlHelper sqlHelper = new SqlHelper();

            sqlHelper.ExecuteNonQuery(
                "UPDATE User SET Password = '123456' WHERE Id = 1"
            );

            return "done";
        }

        [HttpDelete]
        public string Remove(string userNo, string userName)
        {
            SqlHelper sqlHelper = new SqlHelper();

            sqlHelper.ExecuteNonQuery(
                "DELETE FROM User WHERE UserNo = @UserNo AND UserName = @UserName",
                new MySqlParameter("@UserNo", userNo),
                new MySqlParameter("@UserName", userName)
            );
            return "done";
        }
    }
}
