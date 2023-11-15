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

        string sqlCommand = $"INSERT INTO jobseeker (name, date_of_birth, person_number, city_id, email, telephone) VALUES (@Name, '{jobSeeker.DateOfBirth}', '{jobSeeker.PersonNumber.PNumber}', @CityId, @Email, @Telephone);";
        connection.Execute(sqlCommand, jobSeeker);

        int jobseekerId = connection.Execute("SELECT SCOPE_IDENTITY() AS LastInsertedID;");

        return jobseekerId;
    }

    public JobSeeker GetJobSeekerById(int jobSeeker_id)
    {
        ConnectToDatabase();

        /* try
        {
            JobSeeker jobSeeker = connection.QuerySingle<JobSeeker>($"SELECT id, name FROM jobseeker WHERE jobseeker.id = {jobSeeker_id}");
            return jobSeeker;
        }
        catch (System.InvalidOperationException ex)
        {
            System.Console.WriteLine(ex.Message);
        } */

        JobSeeker jobSeeker = connection.QuerySingle<JobSeeker>($"SELECT name, date_of_birth, person_number, city_id, email, telephone FROM jobseeker WHERE jobseeker.id = {jobSeeker_id}");
        return jobSeeker;
    }

    public IEnumerable<JobSeeker> GetAllJobSeekers()
    {
        ConnectToDatabase();
        IEnumerable<JobSeeker> jobSeekers = connection.Query<JobSeeker>("SELECT name, date_of_birth, person_number, city_id, email, telephone FROM jobseeker");

        return jobSeekers;
    }
}