using Model;
public interface IEmployerRepository : IRepository
{
    void ConnectToDatabase();
    int AddEmployer(Employer employer);
    Employer GetEmployerById(int employerId);
    IEnumerable<Employer> GetAllEmployers();
}