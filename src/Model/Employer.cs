namespace Model;
public class Employer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OrganisationNumber { get; set; }
    public int IndustryId { get; set; }
    // public string Industry { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public int CityId { get; set; }

    public Employer(string name, string organisationNumber, int industryId, string email, int cityId)
    {
        Name = name;
        OrganisationNumber = organisationNumber;
        IndustryId = industryId;
        Email = email;
        CityId = cityId;
    }

    public Employer(int id, string name, string organisationNumber, int industryId, string email, int cityId)
    {
        Id = id;
        Name = name;
        OrganisationNumber = organisationNumber;
        IndustryId = industryId;
        Email = email;
        CityId = cityId;
    }


}