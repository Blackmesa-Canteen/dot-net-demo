namespace MyBBSWebApi.BLL.Interfaces;

public interface IUserBll
{
    bool CheckLogin(string userNo, string password);
}