using Model;
public interface IJobSeekerRepository : IRepository
{
    void ConnectToDatabase();
    int AddJobSeeker(JobSeeker jobSeeker);
    JobSeeker GetJobSeekerById(int jobSeekerId);
    IEnumerable<JobSeeker> GetAllJobSeekers();
}