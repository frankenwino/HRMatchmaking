using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

public class JobSeekerRepository
{
    private IDbConnection connection;

    public JobSeekerRepository(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        connection = new SqlConnection(connectionString);
    }

    private void Open()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public int AddJobseeker(JobSeeker jobSeeker)
    {
        Open();
        string sqlCommand = "INSERT INTO job_seeker (name) VALUES (@Name);SELECT SCOPE_IDENTITY;";
        int id = connection.QuerySingle<int>(sqlCommand, jobSeeker);

        return id;
    }

    public IEnumerable<JobSeeker> GetAllJobSeekers()
    {
        Open();
        IEnumerable<JobSeeker> jobSeekers = connection.Query<JobSeeker>("SELECT id, name from job_seeker;");

        return jobSeekers;
    }
}