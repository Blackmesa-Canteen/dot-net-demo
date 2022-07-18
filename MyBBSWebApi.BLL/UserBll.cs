using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.MODEL;
using WebApiDemo.Dal;

namespace MyBBSWebApi.BLL;

public class UserBll : IUserBll
{
    private UserDal _userDal = new UserDal();
    public bool CheckLogin(string userNo, string password)
    {
        User? user = _userDal.GetUserByUserNoAndPassword(userNo, password);

        return user != null;
    }
}