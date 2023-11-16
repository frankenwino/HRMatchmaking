using System.Data;
using Dapper;
using System.Data.SqlClient;

public class JobSeekerRepository : IJobSeekerRepository
{
    private IDbConnection connection;

    public JobSeekerRepository(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        connection = new SqlConnection(connectionString);
    }

    public void ConnectToDatabase()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public int AddJobSeeker(JobSeeker jobSeeker)
    {
        ConnectToDatabase();

        string sqlCommand = $"INSERT INTO jobseeker (name, date_of_birth, person_number, city_id, email, telephone) VALUES (@Name, '{jobSeeker.DateOfBirth}', @PersonNumber, @CityId, @Email, @Telephone);";
        connection.Execute(sqlCommand, jobSeeker);

        int jobseekerId = connection.Execute("SELECT SCOPE_IDENTITY() AS LastInsertedID;");

        return jobseekerId;
    }

    public JobSeeker GetJobSeekerById(int jobSeekerId)
    {
        ConnectToDatabase();

        JobSeeker jobSeeker = connection.QuerySingle<JobSeeker>($"SELECT id AS Id, name AS Name, date_of_birth AS DateOfBirth, person_number AS PersonNumber, city_id AS CityId, telephone AS Telephone, email AS Email FROM jobseeker WHERE jobseeker.id = {jobSeekerId}");

        return jobSeeker;
    }

    public IEnumerable<JobSeeker> GetAllJobSeekers()
    {
        ConnectToDatabase();

        // IEnumerable<JobSeeker> jobSeekers = connection.Query<JobSeeker>("SELECT id, name, date_of_birth, person_number, city_id, telephone, email FROM jobseeker");
        IEnumerable<JobSeeker> jobSeekers = connection.Query<JobSeeker>(
            "SELECT id AS Id, name AS Name, CAST(date_of_birth AS date) AS DateOfBirth, person_number AS PersonNumber, city_id AS CityId, telephone AS Telephone, email AS Email FROM jobseeker");

        return jobSeekers;
    }
}

// CAST(date_of_birth AS DateOfBirth)