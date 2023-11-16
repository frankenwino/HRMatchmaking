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
}