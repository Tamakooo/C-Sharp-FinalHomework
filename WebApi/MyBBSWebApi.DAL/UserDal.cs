using MySqlConnector;
using System.Data;
using WebApi.Dal.Core;
using WebApi.Models;

namespace MyBBSWebApi.DAL
{
    public class UserDal
    {
        public List<Users> GetAll()
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM users");
            List<Users> userList = ToModelList(res);
            return userList;
        }
        public Users GetUserByid(int id)
        {
            DataRow row = null;
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM users WHERE id = @id",
                new MySqlParameter("@id", id));
            if (res.Rows.Count > 0)
            {
                row = res.Rows[0];
            }
            Users user = ToModel(row);
            return user;
        }

        public List<Users> GetUserByNoPa(int userNo, string password)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM users WHERE UserNo = @UserNo AND Password = @Password",
                new MySqlParameter("@UserNo", userNo),
                new MySqlParameter("@Password", password));

            List<Users> userList = ToModelList(res);
            return userList;

        }

        public int AddUser(int userNo, string userName, string userLevel, string password)
        {
            return SqlHelper.ExecuteNonQuery(
                "INSERT INTO users(UserNo,UserName,UserLevel,`Password`) VALUES(@userNo,@userName,@userLevel,@password)",
                new MySqlParameter("@userNo", userNo),
                new MySqlParameter("@userName", userName),
                new MySqlParameter("@userLevel", userLevel),
                new MySqlParameter("@password", password));
        }

        public int UpdateUser(int id, int? userNo, string userName, string userLevel, string password)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM users WHERE id = @id", new MySqlParameter("@id", id));
            int rowCount = 0;
            if (res.Rows.Count > 0)
            {
                DataRow row = res.Rows[0];
                Users user = new Users();
                user.id = (int)row["id"];
                user.UserNo = userNo ?? (int)row["UserNo"];
                user.UserName = userName ?? row["UserName"].ToString();
                user.UserLevel = userLevel ?? row["UserLevel"].ToString();
                user.Password = password ?? row["Password"].ToString();
                rowCount = SqlHelper.ExecuteNonQuery(
                    "UPDATE users SET UserNo = @UserNo,UserName = @UserName,UserLevel = @UserLevel,`Password` = @Password WHERE id = @id",
                    new MySqlParameter("@id", user.id),
                    new MySqlParameter("@UserNo", user.UserNo),
                    new MySqlParameter("@UserName", user.UserName),
                    new MySqlParameter("@UserLevel", user.UserLevel),
                    new MySqlParameter("@Password", user.Password));
            }
            return rowCount;
        }

        public int RemoveUser(int id)
        {
            return SqlHelper.ExecuteNonQuery(
                "DELETE FROM users WHERE id = @id",
                new MySqlParameter("@id", id));
        }

        private Users ToModel(DataRow row)
        {
            Users user = new Users();
            user.id = (int)row["id"];
            user.UserNo = (int)row["UserNo"];
            user.UserName = row["UserName"].ToString();
            user.UserLevel = row["UserLevel"].ToString();
            user.Password = row["Password"].ToString();
            user.IsDelete = (bool)row["IsDelete"];
            return user;
        }

        private List<Users> ToModelList(DataTable res)
        {
            List<Users> userList = new List<Users>();
            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow row = res.Rows[i];
                Users user = ToModel(row);
                userList.Add(user);
            }
            return userList;
        }
    }
}