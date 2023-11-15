namespace ConsoleInputUtility;
public class ConsoleInput
{
    /// <summary>
    /// Displays a user prompt on the console without a new line.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display.</param>
    private static void DisplayUserPrompt(string userPrompt)
    {
        System.Console.Write($"{userPrompt}: ");
    }

    /// <summary>
    /// Prompts the user to enter a string and validates the input.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter a string").</param>
    /// <returns>The string entered by the user.</returns>
    static public string GetString(string userPrompt = "Enter a string")
    {
        bool validString = false;
        string userResponse;

        do
        {
            DisplayUserPrompt(userPrompt);
            userResponse = Console.ReadLine();
            validString = !string.IsNullOrEmpty(userResponse);

        } while (validString == false);

        return userResponse;
    }

    /// <summary>
    /// Prompts the user to enter an unsigned integer and validates the input.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter an unsigned integer").</param>
    /// <returns>The unsigned integer entered by the user.</returns>
    static public uint GetUint(string userPrompt = "Enter an unsigned integer")
    {
        bool validUint = false;
        uint myUint;

        do
        {
            string response = GetString(userPrompt);
            validUint = UInt32.TryParse(response, out myUint);

        } while (validUint == false);

        return myUint;
    }

    /// <summary>
    /// Prompts the user to enter an integer and validates the input.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter an integer").</param>
    /// <returns>The integer entered by the user.</returns>
    static public int GetInt(string userPrompt = "Enter an integer")
    {
        bool validInt = false;
        int myInt;

        do
        {
            string response = GetString(userPrompt);
            validInt = Int32.TryParse(response, out myInt);

        } while (validInt == false);

        return myInt;
    }

    /// <summary>
    /// Prompts the user to enter a year in the format YYYY and validates the input.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter a year [YYYY]").</param>
    /// <returns>The DateOnly representing the entered year.</returns>
    static public DateOnly GetYear(string userPrompt = "Enter a year [YYYY]")
    {
        bool validYearOnly = false;
        DateOnly yearOnly = new();

        do
        {
            int year = GetInt(userPrompt);

            try
            {
                yearOnly = new DateOnly(year, 1, 1);
                validYearOnly = true;
            }

            catch (System.ArgumentOutOfRangeException)
            {
                PromptUser.DisplayFeedback("Invalid year");
            }

        } while (validYearOnly == false);

        return yearOnly;
    }

    /// <summary>
    /// Prompts the user to enter a date in the format YYYY-MM-DD and validates the input.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter a date [YYYY-MM-DD]").</param>
    /// <returns>The DateOnly representing the entered date.</returns>
    static public DateOnly GetDateOnly(string userPrompt = "Enter a date [YYYY-MM-DD]")
    {
        bool validDateOnly = false;
        DateOnly myDateOnly = new();

        do
        {
            string dateOnlyString = GetString(userPrompt);
            validDateOnly = DateOnly.TryParse(dateOnlyString, out myDateOnly);

            if (validDateOnly == false)
            {
                PromptUser.DisplayFeedback("Invalid date");
            }

        } while (validDateOnly == false);

        return myDateOnly;
    }


    public static string GetPersonNumberLastFourNumbers(string userPrompt = "Enter last four numbers of person number")
    {
        bool validLastFourNumbers = false;
        uint myLastFourNumbers;
        do
        {
            myLastFourNumbers = GetUint(userPrompt);

            if (myLastFourNumbers.ToString().Length == 4)
            {
                validLastFourNumbers = true;
            }

            else
            {
                PromptUser.DisplayFeedback("Invalid format");
            }

        } while (validLastFourNumbers == false);

        return myLastFourNumbers.ToString();
    }

    /// <summary>
    /// Prompts the user to enter a date in the format YYYY-MM-DD and optionally provides an hour in the format [HH:mm].
    /// Converts the entered date to a DateTime with the specified or default hour.
    /// </summary>
    /// <param name="userPrompt">The prompt message to display (default is "Enter a date [YYYY-MM-DD]").</param>
    /// <param name="hour">The hour to use in the format [HH:mm] (default is "00:00").</param>
    /// <returns>The DateTime representing the entered date and time.</returns>
    static public DateTime GetDateTimeFromDateOnly(string userPrompt = "Enter a date [YYYY-MM-DD]", string hour = "00:00")
    {
        DateOnly myDateOnly = GetDateOnly(userPrompt);
        DateTime myDateTime = myDateOnly.ToDateTime(TimeOnly.Parse(hour));

        return myDateTime;
    }

    /// <summary>
    /// Prompts the user to select a value from the provided enum type and validates the input.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <returns>The selected enum value of type T.</returns>
    static public T GetFromEnum<T>() where T : Enum
    {
        T userEnumChoice;
        bool validEnumChoice = false;

        foreach (var enumValue in Enum.GetValues(typeof(T)))
        {
            string capitalisedEnumValue = char.ToUpper(enumValue.ToString()[0]) + enumValue.ToString().Substring(1);
            System.Console.WriteLine($"{(int)enumValue + 1}. {capitalisedEnumValue}");
        }

        do
        {
            int userChoice = GetInt("Select from list") - 1;
            validEnumChoice = Enum.IsDefined(typeof(T), userChoice);
            userEnumChoice = (T)Enum.ToObject(typeof(T), userChoice);

        } while (validEnumChoice == false);

        return userEnumChoice;
    }
}