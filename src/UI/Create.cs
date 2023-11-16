using ConsoleInputUtility;
public static class Create
{
    public static JobSeeker JobSeeker()
    {
        // string name = ConsoleInput.GetString("Enter name");
        // DateOnly dateOfBirth = ConsoleInput.GetDateOnly("Enter date of birth [YYYY-MM-DD]");

        // string lastFourNumbers = ConsoleInput.GetPersonNumberLastFourNumbers();
        // PersonNumber personNumber = new PersonNumber(dateOfBirth, lastFourNumbers);

        // int cityId = ConsoleInput.GetInt("Enter the city id");
        // string telephone = ConsoleInput.GetString("Enter phone number");
        // string email = ConsoleInput.GetString("Enter email");

        // JobSeeker j = new JobSeeker(name, dateOfBirth, personNumber.ToString(), cityId, telephone, email);

        Random random = new();
        JobSeeker j = new JobSeeker("Andrew Browne", new DateTime(1975, 1, 1), $"19751211{random.Next(1111, 9999)}", 72, "076876867", "me@email.com");

        return j;
    }
}