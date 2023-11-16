namespace Model;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public City(string name)
    {
        Name = name;
    }

    public City(int id, string name)
    {
        Id = id;
        Name = name;
    }

}