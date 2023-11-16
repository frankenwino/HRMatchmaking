namespace Model;
public class Employer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OrganisationNumber { get; set; }
    public int IndustryId { get; set; }
    public string Industry { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public int CityId { get; set; }

    public Employer(string name, string organisationNumber, string industry, int industryId, string email, string city, int cityId)
    {
        Name = name;
        OrganisationNumber = organisationNumber;
        Industry = industry;
        IndustryId = industryId;
        Email = email;
        City = city;
        CityId = cityId;
    }

    public Employer(string name, string organisationNumber, int industryId, string email, int cityId)
    {
        Name = name;
        OrganisationNumber = organisationNumber;
        IndustryId = industryId;
        Email = email;
        CityId = cityId;
    }
}