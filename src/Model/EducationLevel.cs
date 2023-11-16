namespace Model;

public class EducationLevel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public EducationLevel(string name)
    {
        Name = name;
    }
}