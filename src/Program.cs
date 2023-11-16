using DB.Setup;
using UI;

Console.Clear();
// SetUpDB(); // Comment out after setting up DB connecting to the data base

JobSeekerRepository jsr = new();

// Menu menu = new(jsr);
// menu.RunMainMenu();

// Add some jobseekers

for (int i = 0; i < 2; i++)
{
    JobSeeker j = Create.JobSeeker();
    j.Id = jsr.AddJobSeeker(j);
}

// JobSeeker j = Create.JobSeeker();
/* System.Console.WriteLine(j.Id);
System.Console.WriteLine(j.PersonNumber);
System.Console.WriteLine(j.CityId);
System.Console.WriteLine(j.Telephone);
System.Console.WriteLine(j.Email); */
// j.Id = jsr.AddJobSeeker(j);

// Get all jobseekers and display them
// IEnumerable<JobSeeker> jobSeekers = jsr.GetAllJobSeekers();
// System.Console.WriteLine("All Jobseekers in DB");
// foreach (JobSeeker jobSeeker in jobSeekers)
// {
//     System.Console.WriteLine(j.Id);
//     System.Console.WriteLine(j.Name);
//     System.Console.WriteLine(j.PersonNumber);
//     System.Console.WriteLine(j.CityId);
//     System.Console.WriteLine(j.Telephone);
//     System.Console.WriteLine(j.Email);
//     System.Console.WriteLine();
// }
// System.Console.WriteLine();

// Get jobseeker with id 1
JobSeeker k = jsr.GetJobSeekerById(2);
System.Console.WriteLine($"Jobseeker with id {k.Id}: {k.Name} {k.PersonNumber}");
System.Console.WriteLine(k.Id);
System.Console.WriteLine(k.Name);
System.Console.WriteLine(k.PersonNumber);
System.Console.WriteLine(k.CityId);
System.Console.WriteLine(k.Telephone);
System.Console.WriteLine(k.Email);

void SetUpDB()
{
    DBSetup dbs = new();
    dbs.DropAllTables();
    dbs.CreateAllTables();
    System.Console.WriteLine("Comment out the line calling SetUpDB() - on line 6 or so.");
    Environment.Exit(0);
}