public class PersonNumber
{
    public DateOnly DateOfBirth { get; set; }
    public string FourLastNumbers { get; set; }
    public string PNumber
    {
        get { return GetPersonNumber(); }
    }

    public PersonNumber(DateOnly dateOfBirth, string fourLastNumbers)
    {
        DateOfBirth = dateOfBirth;
        FourLastNumbers = fourLastNumbers;
    }

    private string Zeroer(int i)
    {
        string zeroed;

        if (i < 10)
        {
            zeroed = $"0{i}";
        }
        else
        {
            zeroed = i.ToString();
        }

        return zeroed;
    }

    public string GetPersonNumber()
    {
        string year = DateOfBirth.Year.ToString();
        string month = Zeroer(DateOfBirth.Month);
        string day = Zeroer(DateOfBirth.Day);

        return $"{DateOfBirth.Year}{month}{day}-{FourLastNumbers}";
    }
}
