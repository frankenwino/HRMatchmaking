public static class Create
{
    public static JobSeeker JobSeeker()
    {
        System.Console.Write("Enter name: ");
        string name = Console.ReadLine();

        JobSeeker j = new JobSeeker(name);

        return j;
    }
}