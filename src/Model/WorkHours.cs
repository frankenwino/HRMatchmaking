namespace Model;

class WorkHours
{
    public int Id { get; set; }
    public int Hours { get; set; }
    public WorkHours(int hours = 100)
    {
        Hours = hours;
    }
}