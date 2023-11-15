public static class Create
{
    public static Jobseeker Jobseeker()
    {
        System.Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Jobseeker j = new Jobseeker(name);

        return j;
    }
}