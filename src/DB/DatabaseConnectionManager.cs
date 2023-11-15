using System.Data.SqlClient;

public class DatabaseConnectionManager : IDisposable
{
    private readonly string connectionString;
    private SqlConnection connection;

    public DatabaseConnectionManager(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        this.connectionString = connectionString;
    }

    public SqlConnection GetOpenConnection()
    {
        if (connection == null)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        else if (connection.State == System.Data.ConnectionState.Closed)
        {
            connection.Open();
        }

        return connection;
    }

    public void CloseConnection()
    {
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public void Dispose()
    {
        CloseConnection();
        connection.Dispose();
    }
}

/* class Program
{
    static void Main()
    {
        string yourConnectionString = "your_actual_connection_string_here";

        using (DatabaseConnectionManager dbConnectionManager = new DatabaseConnectionManager(yourConnectionString))
        {
            // Use the database connection
            using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
            {
                // Perform database operations using the connection
                // ...
            }

            // The connection is automatically closed when the using block is exited
        }
    }
} */
