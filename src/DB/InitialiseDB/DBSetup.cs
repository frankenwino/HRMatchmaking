namespace DB.Setup;
using System.Data.SqlClient;
using Dapper;

public class DBSetup
{
    private List<string> dropTables = new List<string>{
        "DROP TABLE skill_to_job;",
        "DROP TABLE job;",
        "DROP TABLE work_hours;",
        "DROP TABLE vehicle_license_to_jobseeker;",
        "DROP TABLE skill_to_jobseeker;",
        "DROP TABLE skill;",
        "DROP TABLE language_to_jobseeker;",
        "DROP TABLE language_level;",
        "DROP TABLE language;",
        "DROP TABLE subject_to_education_level;",
        "DROP TABLE education_level;",
        "DROP TABLE subject;",
        "DROP TABLE job_history;",
        "DROP TABLE employer;",
        "DROP TABLE industry;",
        "DROP TABLE jobseeker;",
        "DROP TABLE city;",
        "DROP TABLE vehicle_license;"
    };
    private string createVehicleLicenseTable = @"
    CREATE TABLE vehicle_license (
        id INT PRIMARY KEY IDENTITY(1,1),
        code VARCHAR(8) UNIQUE NOT NULL,
        description VARCHAR(64) NOT NULL
    );";

    private string createCityTable = @"
    CREATE TABLE city (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createJobseekerTable = @"
    CREATE TABLE jobseeker (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(64) NOT NULL,
        date_of_birth DATE NOT NULL,
        person_number VARCHAR(12) UNIQUE NOT NULL,
        city_id INT NOT NULL,
        email VARCHAR(64),
        telephone VARCHAR(32) NOT NULL,
        FOREIGN KEY (city_id) REFERENCES city (id)
    );";

    private string createIndustryTable = @"
    CREATE TABLE industry (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createEmployerTable = @"
    CREATE TABLE employer (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(64) UNIQUE NOT NULL,
        organisation_number VARCHAR(12) UNIQUE NOT NULL,
        city_id INT NOT NULL,
        industry_id INT NOT NULL,
        email VARCHAR(64) NOT NULL,
        FOREIGN KEY (city_id) REFERENCES city(id),
        FOREIGN KEY (industry_id) REFERENCES industry(id)
    );";

    private string createJobHistoryTable = @"
    CREATE TABLE job_history (
        id INT PRIMARY KEY IDENTITY(1,1),
        job_title VARCHAR(32) NOT NULL,
        start_date DATE NOT NULL,
        end_date DATE NOT NULL,
        tasks TEXT NOT NULL,
        employer VARCHAR(32) NOT NULL,
        jobseeker_id INT NOT NULL,
        FOREIGN KEY (jobseeker_id) REFERENCES jobseeker(id) ON DELETE CASCADE
    );";

    private string createSubjectTable = @"
    CREATE TABLE subject (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createEducationLevel = @"
    CREATE TABLE education_level (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createSubjectToEducationLevel = @"
    CREATE TABLE subject_to_education_level (
        subject_id INT NOT NULL,
        jobseeker_id INT NOT NULL,
        certification_date DATE NOT NULL,
        education_level_id INT NOT NULL,
        FOREIGN KEY (subject_id) REFERENCES subject(id),
        FOREIGN KEY (jobseeker_id) REFERENCES jobseeker(id) ON DELETE CASCADE,
        FOREIGN KEY (education_level_id) REFERENCES education_level(id)
    );";

    private string createLanguageTable = @"
    CREATE TABLE language (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createLanguageLevelTable = @"
    CREATE TABLE language_level
    (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createLanguageToJobseekerTable = @"
    CREATE TABLE language_to_jobseeker
    (
        language_id INT NOT NULL,
        jobseeker_id INT NOT NULL,
        language_level_id INT NOT NULL,
        FOREIGN KEY (jobseeker_id) REFERENCES jobseeker(id) ON DELETE CASCADE,
        FOREIGN KEY (language_level_id) REFERENCES language_level(id)
    );";

    private string createSkillTable = @"
    CREATE TABLE skill
    (
        id INT PRIMARY KEY IDENTITY(1,1),
        name VARCHAR(32) UNIQUE NOT NULL
    );";

    private string createSkillToJobseekerTable = @"
    CREATE TABLE skill_to_jobseeker
    (
        skill_id INT NOT NULL,
        jobseeker_id INT NOT NULL,
        FOREIGN KEY (skill_id) REFERENCES skill(id),
        FOREIGN KEY (jobseeker_id) REFERENCES jobseeker(id) ON DELETE CASCADE
    );
    ";

    private string createVehicleLicenseToJobseekerTable = @"
    CREATE TABLE vehicle_license_to_jobseeker
    (
        vehicle_license_id INT NOT NULL,
        jobseeker_id INT NOT NULL,
        acquired DATE NOT NULL,
        FOREIGN KEY (vehicle_license_id) REFERENCES vehicle_license(id),
        FOREIGN KEY (jobseeker_id) REFERENCES jobseeker(id) ON DELETE CASCADE
    );";

    private string createWorkHoursTable = @"
    CREATE TABLE work_hours
    (
        id INT PRIMARY KEY IDENTITY(1,1),
        hours INT UNIQUE NOT NULL
    );";

    private string createJobTable = @"
    CREATE TABLE job
    (
        id INT PRIMARY KEY IDENTITY(1,1),
        education_level_id INT NOT NULL,
        employer_id INT NOT NULL,
        industry_id INT NOT NULL,
        job_title VARCHAR(64) NOT NULL,
        description TEXT NOT NULL,
        vehicle_license_id INT NOT NULL,
        access_to_own_car BIT NOT NULL,
        remote_option BIT NOT NULL,
        work_hours_id INT NOT NULL,
        application_deadline DATE NOT NULL,
        city_id INT NOT NULL,
        FOREIGN KEY (education_level_id) REFERENCES education_level(id),
        FOREIGN KEY (employer_id) REFERENCES employer(id) ON DELETE CASCADE,
        FOREIGN KEY (industry_id) REFERENCES industry(id),
        FOREIGN KEY (work_hours_id) REFERENCES work_hours(id),
        FOREIGN KEY (city_id) REFERENCES city(id)
    );";

    private string createSkillToJobTable = @"
    CREATE TABLE skill_to_job
    (
        skill_id INT NOT NULL,
        job_id INT NOT NULL,
        FOREIGN KEY (skill_id) REFERENCES skill(id),
        FOREIGN KEY (job_id) REFERENCES job(id) ON DELETE CASCADE
    );
    ";

    public void DropAllTables()
    {
        DatabaseConnectionManager dbConnectionManager = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            foreach (string sql in dropTables)
            {
                try
                {
                    connection.Execute(sql);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("All existing tables dropped");
        }
    }

    public void CreateAllTables()
    {
        List<string> createTableSqlCommands = new();

        createTableSqlCommands.Add(createVehicleLicenseTable);
        createTableSqlCommands.Add(createCityTable);
        createTableSqlCommands.Add(createJobseekerTable);
        createTableSqlCommands.Add(createIndustryTable);
        createTableSqlCommands.Add(createEmployerTable);
        createTableSqlCommands.Add(createEducationLevel);
        createTableSqlCommands.Add(createSubjectTable);
        createTableSqlCommands.Add(createJobHistoryTable);
        createTableSqlCommands.Add(createSubjectToEducationLevel);
        createTableSqlCommands.Add(createLanguageTable);
        createTableSqlCommands.Add(createLanguageLevelTable);
        createTableSqlCommands.Add(createLanguageToJobseekerTable);
        createTableSqlCommands.Add(createSkillTable);
        createTableSqlCommands.Add(createSkillToJobseekerTable);
        createTableSqlCommands.Add(createVehicleLicenseToJobseekerTable);
        createTableSqlCommands.Add(createWorkHoursTable);
        createTableSqlCommands.Add(createJobTable);
        createTableSqlCommands.Add(createSkillToJobTable);

        DatabaseConnectionManager dbConnectionManager = new();

        using (SqlConnection connection = dbConnectionManager.GetOpenConnection())
        {
            foreach (string sql in createTableSqlCommands)
            {
                // System.Console.WriteLine(sql);
                connection.Execute(sql);
            }

            System.Console.WriteLine("New tables created successfully");
        }
    }
}