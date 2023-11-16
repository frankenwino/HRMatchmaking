using DB.Setup;
using UI;
using Model;
using Spectre.Console;

Console.Clear();
SetUpDB(); // Comment out after setting up DB connecting to the data base

JobSeekerRepository jsr = new();
EmployerRepository er = new();

// Menu menu = new(jsr);
// menu.RunMainMenu();


// Query database and display results
DisplayAllJobSeekers();
DisplayOneJobSeeker();
DisplayAllEmployers();
DisplayOneEmployer();
Environment.Exit(0);


Table CreateSpectreTable(List<string> columns)
{
    Table table = new Table();
    foreach (string column in columns)
    {
        table.AddColumn(column);
    }

    return table;
}

void DisplayAllJobSeekers()
{
    // Set up table
    List<string> columns = new List<string> { "Id", "Name", "PersonNumber", "CityId", "Telephone", "Email" };
    var table = CreateSpectreTable(columns);

    // Get jobseekers
    IEnumerable<JobSeeker> jobSeekers = jsr.GetAllJobSeekers();

    // Add JobSeeker data to table
    foreach (JobSeeker jobSeeker in jobSeekers)
    {
        table.AddRow($"{jobSeeker.Id}", $"{jobSeeker.Name}", $"{jobSeeker.PersonNumber}", $"{jobSeeker.CityId}", $"{jobSeeker.Telephone}", $"{jobSeeker.Email}");
    }

    // Display Jobseekers table
    System.Console.WriteLine("All Jobseekers in DB");
    AnsiConsole.Write(table);
}

void DisplayOneJobSeeker(int id = 1)
{
    // Set up table
    List<string> columns = new List<string> { "Id", "Name", "PersonNumber", "CityId", "Telephone", "Email" };
    var table = CreateSpectreTable(columns);

    // Get jobseeker with id jobSeekerId
    JobSeeker jobSeeker = jsr.GetJobSeekerById(id);
    table.AddRow($"{jobSeeker.Id}", $"{jobSeeker.Name}", $"{jobSeeker.PersonNumber}", $"{jobSeeker.CityId}", $"{jobSeeker.Telephone}", $"{jobSeeker.Email}");

    // Display Jobseekers table
    System.Console.WriteLine($"Jobseeker with id {id}");
    AnsiConsole.Write(table);
}

void DisplayAllEmployers()
{
    // Set up table
    List<string> columns = new List<string> { "Id", "Name", "Org. Number", "CityId", "IndustryId", "Email" };
    var table = CreateSpectreTable(columns);

    // Get all employers
    IEnumerable<Employer> employers = er.GetAllEmployers();

    // Add employer data to table
    foreach (Employer employer in employers)
    {
        table.AddRow($"{employer.Id}", $"{employer.Name}", $"{employer.OrganisationNumber}", $"{employer.CityId}", $"{employer.IndustryId}", $"{employer.Email}");
    }

    // Display employers
    System.Console.WriteLine("All Employers in DB");
    AnsiConsole.Write(table);
}

void DisplayOneEmployer(int id = 1)
{
    // Set up table
    List<string> columns = new List<string> { "Id", "Name", "Org. Number", "CityId", "IndustryId", "Email" };
    var table = CreateSpectreTable(columns);

    // Get jobseeker with id jobSeekerId
    Employer employer = er.GetEmployerById(id);
    table.AddRow($"{employer.Id}", $"{employer.Name}", $"{employer.OrganisationNumber}", $"{employer.CityId}", $"{employer.IndustryId}", $"{employer.Email}");

    // Display Jobseekers table
    System.Console.WriteLine($"Employer with id {id}");
    AnsiConsole.Write(table);
}

void SetUpDB()
{
    // Create tables
    DBSetup dbs = new();
    dbs.DropAllTables();
    dbs.CreateAllTables();


    PopulateDB popDb = new();
    // Add 'enums' to database
    popDb.AddCities();
    popDb.AddIndustries();
    popDb.AddVehicleLicenses();
    popDb.AddEducationLevels();
    popDb.AddLanguages();
    popDb.AddLanguageLevels();
    popDb.AddWorkHours();

    // Add dummy data to database
    popDb.AddJobSeekers(10);
    popDb.AddEmployers(10);
    // Add Job
    // Add 

    System.Console.WriteLine("Comment out the line calling SetUpDB() - on line 6 or so.");
    Environment.Exit(0);
}