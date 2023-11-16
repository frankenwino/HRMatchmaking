namespace Model;
public class Job
{
    public int Id { get; set; }
    public int EducationLevelId { get; set; }
    public int EmployerId { get; set; }
    public int IndustryId { get; set; }
    public string JobTitle { get; set; }
    public string Description { get; set; }
    public int VehicleLicenseId { get; set; }
    public bool AccessToOwnCar { get; set; }
    public bool RemoteOption { get; set; }
    public int WorkHoursId { get; set; }
    public DateTime ApplicationDeadline { get; set; }
    public int CityId { get; set; }
    public string City { get; set; }

    public Job(int educationLevelId, int employerId, int industryId, string jobTitle, string description, int vehicleLicenseId, bool accessToOwnCar, bool remoteOption, int workHoursId, DateTime applicationDeadline, int cityId, string city, int countyId, string county)
    {
        EducationLevelId = educationLevelId;
        EmployerId = employerId;
        IndustryId = industryId;
        JobTitle = jobTitle;
        Description = description;
        VehicleLicenseId = vehicleLicenseId;
        AccessToOwnCar = accessToOwnCar;
        RemoteOption = remoteOption;
        WorkHoursId = workHoursId;
        ApplicationDeadline = applicationDeadline;
        CityId = cityId;
        City = city;
    }

    public Job(int id, int educationLevelId, int employerId, int industryId, string jobTitle, string description, int vehicleLicenseId, bool accessToOwnCar, bool remoteOption, int workHoursId, DateTime applicationDeadline, int cityId, string city, int countyId, string county)
    {
        Id = id;
        EducationLevelId = educationLevelId;
        EmployerId = employerId;
        IndustryId = industryId;
        JobTitle = jobTitle;
        Description = description;
        VehicleLicenseId = vehicleLicenseId;
        AccessToOwnCar = accessToOwnCar;
        RemoteOption = remoteOption;
        WorkHoursId = workHoursId;
        ApplicationDeadline = applicationDeadline;
        CityId = cityId;
        City = city;

    }
}