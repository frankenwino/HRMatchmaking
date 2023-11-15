using ConsoleInputUtility;
public static class Create
{
    public static JobSeeker JobSeeker()
    {
        string name = ConsoleInput.GetString("Enter name:");
        DateOnly dateOfBirth = ConsoleInput.GetDateOnly("Enter dateo of birth [YYYY-MM-DD]:");

        string lastFourNumbers = ConsoleInput.GetPersonNumberLastFourNumbers();
        PersonNumber personNumber = new PersonNumber(dateOfBirth, lastFourNumbers);
        // PersonNumber personNumber = new PersonNumber(dateOfBirth, ConsoleInput.GetPersonNumberLastFourNumbers());
        int cityId = ConsoleInput.GetInt("Enter the city id:");
        string city = ConsoleInput.GetString("Enter city;");
        string telephone = ConsoleInput.GetString("Enter phonenumber:");
        string email = ConsoleInput.GetString("Enter email:");

        System.Console.WriteLine($"Telephone: {telephone}");


        JobSeeker j = new JobSeeker(name, dateOfBirth, personNumber, cityId, telephone, email);

        return j;
    }
}