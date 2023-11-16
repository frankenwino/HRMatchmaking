namespace Model;

public class Industry
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Industry(string name)
    {
        Name = name;
    }

    public Industry(int id, string name)
    {
        Id = id;
        Name = name;
    }
}