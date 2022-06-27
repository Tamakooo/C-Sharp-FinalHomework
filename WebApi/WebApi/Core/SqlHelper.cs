using MySqlConnector;
using System.Data;

namespace WebApi.Dal.Core
{
    public class SqlHelper
    {
        public static string ConnectString { get; set; } = "server=127.0.0.1;username=root;password=czh20021231;database=mybbsdb;charset=utf8mb4";

        public static DataTable ExecuteTable(string cmdText,params MySqlParameter[] sqlParameters)
        {
            using MySqlConnection conn = new MySqlConnection(ConnectString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteNonQuery(string cmdText,params MySqlParameter[] sqlParameters)
        {
            using MySqlConnection conn = new MySqlConnection(ConnectString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteNonQuery();
        }
    }
}
