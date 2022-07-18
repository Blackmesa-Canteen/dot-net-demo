using System.Data;
using MySqlConnector;
using WebApiDemo.Core;

namespace WebApiDemo.Dal;

public class UserDal
{
    public User? GetUserByUserNoAndPassword(string userNo, string password)
    {
        DataTable res = SqlHelper.ExecuteTable("SELECT * FROM User WHERE UserNo = @UserNo AND Password = @Password",
            new MySqlParameter("@UserNo", userNo),
            new MySqlParameter("@Password", password));
        DataRow dataRow = null;
        if (res.Rows.Count > 0)
        {
            dataRow = res.Rows[0];
        }
        else
        {
            return null;
        }
        
        User user = new User();
            
        user.UserNo = dataRow["UserNo"].ToString();
        user.Password  = dataRow["Password"].ToString();
        user.Id = (int) dataRow["Id"];
        user.UserName = dataRow["UserName"].ToString();
        user.UserLevel = (int) dataRow["UserLevel"];

        return user;
    }
    
    public User? GetUserById(int id)
    {
        DataTable res = SqlHelper.ExecuteTable("SELECT * FROM User WHERE id = @Id",
            new MySqlParameter("@Id", id));
        DataRow dataRow = null;
        if (res.Rows.Count > 0)
        {
            dataRow = res.Rows[0];
        }
        else
        {
            return null;
        }
        
        User user = new User();
            
        user.UserNo = dataRow["UserNo"].ToString();
        user.Password  = dataRow["Password"].ToString();
        user.Id = (int) dataRow["Id"];
        user.UserName = dataRow["UserName"].ToString();
        user.UserLevel = (int) dataRow["UserLevel"];

        return user;
    }

    public int AddUser(User user)
    {
        return SqlHelper.ExecuteNonQuery(
            "INSERT INTO User (UserNo, UserName, UserLevel, Password) VALUES(@UserNo, @UserName, @UserLevel, @Password)",
            new MySqlParameter("@UserNo", user.UserNo),
            new MySqlParameter("@UserName", user.UserName),
            new MySqlParameter("@UserLevel", user.UserLevel),
            new MySqlParameter("@Password", user.Password)
        );
    }

    public int UpdateUser(User user)
    {
        User? prevUser = GetUserById(user.Id);
        if (prevUser != null)
        {
            user.Password = user.Password ?? prevUser.Password;
            user.UserLevel = user.UserLevel ?? prevUser.UserLevel;
            user.UserName = user.UserName ?? prevUser.UserName;
            user.UserNo = user.UserNo ?? prevUser.UserNo;
        }
        
        return SqlHelper.ExecuteNonQuery(
            "UPDATE User SET UserNo = @UserNo, UserName = @UserName, UserLevel = @UserLevel, Password = @Password WHERE id = @id",
            new MySqlParameter("@id", user.Id),
            new MySqlParameter("@UserNo", user.UserNo),
            new MySqlParameter("@UserName", user.UserName),
            new MySqlParameter("@UserLevel", user.UserLevel),
            new MySqlParameter("@Password", user.Password)
        );
    }

    public int RemoveUserById(int id)
    {
        return SqlHelper.ExecuteNonQuery(
            "DELETE FROM User WHERE id = @id",
            new MySqlParameter("@id", id)
        );
    }
    
}