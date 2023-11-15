namespace DB;

using System.Data;
using Dapper;
using System.Data.SqlClient;

public class DBConnect
{
    public IDbConnection connection;

    public DBConnect(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        connection = new SqlConnection(connectionString);
    }

    public void ConnectToDatabase()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }
}

