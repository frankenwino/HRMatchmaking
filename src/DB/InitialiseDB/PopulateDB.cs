namespace DB.Setup;
// using Faker;
using System.Data.SqlClient;
// using Dapper;
using Model;

public class PopulateDB
{
    private Random random;

    public PopulateDB()
    {
        random = new Random();
    }

    public void AddJobSeekers(int totalJobSeekers = 10)
    {
        DatabaseConnectionManager dbConnectionManager = new();
        JobSeekerRepository jsr = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            for (int i = 0; i < totalJobSeekers; i++)
            {
                int cityId = random.Next(1, 250);
                string name = Faker.Name.FullName();
                DateTime dateOfBirth = Faker.Identification.DateOfBirth();
                int lastFourNumbers = random.Next(1111, 9999);
                PersonNumber personNumber = new PersonNumber(dateOfBirth, lastFourNumbers.ToString());

                JobSeeker j = new JobSeeker(name, dateOfBirth, personNumber.PNumber, cityId, Faker.Phone.Number(), Faker.Internet.Email());
                jsr.AddJobSeeker(j);
            }
        }
    }
}