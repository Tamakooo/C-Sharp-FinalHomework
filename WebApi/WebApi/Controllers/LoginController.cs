using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using WebApi.Dal;
using WebApi.Models;
using WebApi.Bll;
using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.BLL;
using MyBBSWebApi.DAL;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public List<Users> GetAll()
        {
            IUserBll userBll = new UserBll();
            List<Users> userList = userBll.GetAll();
            return userList;
        }
        [HttpGet]
        public Users GetLoginRes(int userNo, string password)
        {
            UserBll userBll = new UserBll();
            Users user = userBll.CheckLogin(userNo, password);
            return user;
        }

        [HttpPost]
        public string Insert(int userNo,string userName,string userLevel,string password)
        {
            UserDal userDal = new UserDal();
            int rows = userDal.AddUser(userNo,userName,userLevel,password);
            if (rows > 0)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }

        [HttpPut]
        public string Update(int id,int? userNo,string userName,string userLevel,string password, Guid? token)
        {
            UserDal userDal = new UserDal();
            int rows = userDal.UpdateUser(id, userNo, userName, userLevel, password,token);
            if (rows > 0)
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }

        [HttpDelete]
        public string Remove(int id)
        {
            UserDal userDal = new UserDal();
            int rows = userDal.RemoveUser(id);
            if (rows > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
    }
}
