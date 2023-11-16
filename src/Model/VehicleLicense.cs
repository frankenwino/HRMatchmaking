namespace Model;
public class VehicleLicense
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    public VehicleLicense(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public VehicleLicense(int id, string code, string description)
    {
        Id = id;
        Code = code;
        Description = description;
    }
}