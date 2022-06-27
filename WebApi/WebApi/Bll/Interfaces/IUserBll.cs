using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace MyBBSWebApi.BLL.Interfaces
{
    public interface IUserBll
    {
        List<Users> GetAll();
        Users CheckLogin(int userNo, string password);

    }
}
