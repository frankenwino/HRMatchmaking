using System.Collections;

public class JobSeeker
{
    public int Id { get; set; }
    public string Name { get; set; }

    public JobSeeker(string name)
    {
        Name = name;
    }

    public JobSeeker(int id, string name)
    {
        Id = id;
        Name = name;
    }
}