using DB.Setup;
using UI;

Console.Clear();
//SetUpDB(); // Comment out after setting up DB connecting to the data base

JobSeekerRepository jsr = new();

// Menu menu = new(jsr);
// menu.RunMainMenu();

// Add 3 jobseekers
// for (int i = 0; i < 3; i++)
// {
//     JobSeeker j = Create.JobSeeker();
//     j.Id = jsr.AddJobSeeker(j);
// }

// Get all jobseekers and display them
IEnumerable<JobSeeker> jobSeekers = jsr.GetAllJobSeekers();
System.Console.WriteLine("All Jobseekers in DB");
foreach (JobSeeker jobSeeker in jobSeekers)
{
    System.Console.WriteLine($"{jobSeeker.Id}: {jobSeeker.Name}");
}
System.Console.WriteLine();

// Get jobseeker with id 1
JobSeeker k = jsr.GetJobSeekerById(1);
System.Console.WriteLine($"Jobseeker with{k.Id}: {k.Name}");

void SetUpDB()
{
    DBSetup dbs = new();
    dbs.DropAllTables();
    dbs.CreateAllTables();
    Environment.Exit(0);
}