using MyBBSWebApi.DAL;
using WebApi.Models;

namespace MyBBSWebApi.BLL
{
    public class UserBll
    {
        UserDal userDal = new UserDal();
        public List<Users> GetAll()
        {
            return userDal.GetAll().FindAll(m => !m.IsDelete);
        }
        public Users CheckLogin(int userNo, string password)
        {
            List<Users> userList = userDal.GetUserByNoPa(userNo, password);
            if (userList.Count <= 0)
            {
                return default;//返回默认值
            }
            else
            {
                Users user = userList.Find(m => !m.IsDelete);
                return user;
            }
        }
    }
}