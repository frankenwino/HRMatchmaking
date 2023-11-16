namespace Model;

class Language
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Language(string name)
    {
        Name = name;
    }
}