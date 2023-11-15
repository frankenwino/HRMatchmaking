namespace ConsoleInputUtility;
static public class PromptUser
{
    static public void PressEnterToContinue()
    {
        Console.WriteLine("Press ENTER to continue...");
        System.Console.WriteLine();
        Console.ReadKey();
    }

    static public void DisplayFeedback(string message)
    {
        Console.Write($"\n{message}. ");
        PressEnterToContinue();
    }
}