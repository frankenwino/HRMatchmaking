using System.Data;
using Dapper;
using System.Data.SqlClient;
using Model;

public class EmployerRepository : IEmployerRepository
{
    private IDbConnection connection;

    public EmployerRepository(string connectionString = "Server=localhost,1433;User=sa;Password=apA123!#!;Database=HRMatchmakingLocal")
    {
        connection = new SqlConnection(connectionString);
    }

    public void ConnectToDatabase()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    public int AddEmployer(Employer employer)
    {
        ConnectToDatabase();

        string sqlCommand = $"INSERT INTO Employer (name, organisation_number, city_id, industry_id, email) VALUES (@Name, @OrganisationNumber, @CityId, @IndustryId,  @Email);";
        connection.Execute(sqlCommand, employer);

        int employerId = connection.Execute("SELECT SCOPE_IDENTITY() AS LastInsertedID;");

        return employerId;
    }

    public Employer GetEmployerById(int employerId)
    {
        ConnectToDatabase();

        Employer Employer = connection.QuerySingle<Employer>($"SELECT id AS Id, name AS Name, organisation_number AS OrganisationNumber, city_id AS CityId, industry_id AS IndustryId, email AS Email FROM Employer WHERE Employer.id = {employerId}");

        return Employer;
    }

    public IEnumerable<Employer> GetAllEmployers()
    {
        ConnectToDatabase();

        IEnumerable<Employer> Employers = connection.Query<Employer>(
            "SELECT id AS Id, name AS Name, organisation_number AS OrganisationNumber, city_id AS CityId, industry_id AS IndustryId, email AS Email FROM employer");

        return Employers;

    }
}