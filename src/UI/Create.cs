using ConsoleInputUtility;
using Model;
public static class Create
{
    public static JobSeeker JobSeeker()
    {
        string name = ConsoleInput.GetString("Enter name");
        DateTime dateOfBirth = ConsoleInput.GetDateTimeFromDateOnly("Enter date of birth [YYYY-MM-DD]");

        string lastFourNumbers = ConsoleInput.GetPersonNumberLastFourNumbers();
        PersonNumber personNumber = new PersonNumber(dateOfBirth, lastFourNumbers);

        int cityId = ConsoleInput.GetInt("Enter the city id");
        string telephone = ConsoleInput.GetString("Enter phone number");
        string email = ConsoleInput.GetString("Enter email");

        JobSeeker j = new JobSeeker(name, dateOfBirth, personNumber.ToString(), cityId, telephone, email);

        return j;
    }

    public static Employer Employer()
    {
        string name = ConsoleInput.GetString("Enter employer name");
        string organisationNumber = ConsoleInput.GetString("Enter organisation number");
        int industryId = ConsoleInput.GetInt("Enter industry id");
        // string industry = ConsoleInput.GetString("Enter industry");
        string email = ConsoleInput.GetString("Enter email");
        // string city = ConsoleInput.GetString("Enter city");
        int cityId = ConsoleInput.GetInt("Enter city id");

        // Employer e = new Employer(name, organisationNumber, industry, industryId, email, city, cityId);
        Employer e = new Employer(name, organisationNumber, industryId, email, cityId);

        return e;
    }
}