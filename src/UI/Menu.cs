namespace UI;
using ConsoleInputUtility;
public class Menu
{
    private JobSeekerRepository jsr;
    bool quitMenu = false;
    public Menu(JobSeekerRepository jobSeekerRepository)
    {
        jsr = jobSeekerRepository;
    }

    public void RunMainMenu()
    {
        do
        {
            Console.Clear();
            System.Console.WriteLine("Main Menu\n");
            System.Console.WriteLine("1. JobSeeker Menu");
            System.Console.WriteLine("\nQ. Quit\n");

            string choice = ConsoleInput.GetString(">").ToLower();

            switch (choice)
            {
                case "1":
                    RunJobSeekerMenu();
                    break;

                case "q":
                    quitMenu = true;
                    break;

                default:
                    PromptUser.DisplayFeedback("Invalid choice");
                    break;
            }
        } while (quitMenu == false);
    }

    public void RunJobSeekerMenu()
    {
        bool quitMenu = false;

        do
        {
            Console.Clear();
            System.Console.WriteLine("JobSeeker Menu\n");
            System.Console.WriteLine("1. Add new jobSeeker to database");
            System.Console.WriteLine("\nQ. Quit to main menu\n");

            string choice = ConsoleInput.GetString(">").ToLower();

            switch (choice)
            {
                case "1":
                    JobSeeker j = Create.JobSeeker();
                    jsr.AddJobSeeker(j);
                    break;

                case "q":
                    quitMenu = true;
                    break;

                default:
                    PromptUser.DisplayFeedback("Invalid choice");
                    break;
            }
        } while (quitMenu == false);
    }
}
