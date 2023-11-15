Jobseeker j = Create.Jobseeker();
System.Console.WriteLine($"Name: {j.Name}");

JobseekerRepository jsr = new();
j.Id = jsr.AddJobseeker(j);

