namespace Model;

public class LanguageLevel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public LanguageLevel(string name)
    {
        Name = name;
    }
}