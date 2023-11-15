using System.Data;
// using Microsoft.Data.SqlClient;
using Dapper;
using System.Data.SqlClient;

public class JobseekerRepository// : IJobseekerRepository
{
    private IDbConnection connection;

    public JobseekerRepository(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        connection = new SqlConnection(connectionString);
    }

    private void Open()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public int AddJobseeker(Jobseeker jobseeker)
    {
        Open();
        string sqlCommand = "INSERT INTO job_seeker (name) VALUES (@Name)";

        connection.Execute(sqlCommand, jobseeker);

        return 1;
    }

    public IEnumerable<Jobseeker> GetAllJobseekers()
    {
        Open();
        IEnumerable<Jobseeker> jobseekers = connection.Query<Jobseeker>("SELECT id, name from job_seeker;");

        return jobseekers;
    }
}