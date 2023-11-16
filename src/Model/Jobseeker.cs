namespace Model;
public class JobSeeker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    // public PersonNumber PersonNumber { get; set; }
    public string PersonNumber { get; set; }
    public int CityId { get; set; }
    // public string City { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }

    // public JobSeeker(string name, DateOnly dateOfBirth, PersonNumber personNumber, int cityId, string city, string telephone, string email)
    // {
    //     Name = name;
    //     DateOfBirth = dateOfBirth;
    //     PersonNumber = personNumber;
    //     Telephone = telephone;
    //     CityId = cityId;
    //     City = city;
    //     Email = email;
    // }

    public JobSeeker(int id, string name, DateTime dateOfBirth, string personNumber, int cityId, string telephone, string email)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
        PersonNumber = personNumber;
        Telephone = telephone;
        CityId = cityId;
        Email = email;
    }

    public JobSeeker(string name, DateTime dateOfBirth, string personNumber, int cityId, string telephone, string email)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        PersonNumber = personNumber;
        Telephone = telephone;
        CityId = cityId;
        Email = email;
    }

    // private JobSeeker()
    // {
    // }
}