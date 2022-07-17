using System.Data;
using MySqlConnector;

namespace WebApiDemo.Core;

public class SqlHelper
{
    private string ConnectionString { get; set; } = "Server=localhost;Database=MyBBSDb;Uid=root;Pwd=123456";

    public DataTable ExecuteTable(string cmdText, params MySqlParameter[] sqlParameters)
    {
        using MySqlConnection conn = new MySqlConnection(ConnectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(cmdText, conn);
        cmd.Parameters.AddRange(sqlParameters);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds.Tables[0];
    }

    public int ExecuteNonQuery(string cmdText, params MySqlParameter[] sqlParameters)
    {
        using MySqlConnection conn = new MySqlConnection(ConnectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(cmdText, conn);
        cmd.Parameters.AddRange(sqlParameters);
        return cmd.ExecuteNonQuery();
    }
}