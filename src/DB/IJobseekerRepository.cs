public interface IJobSeekerRepository : IRepository
{
    void ConnectToDatabase();
    int AddJobSeeker(JobSeeker jobSeeker);
    JobSeeker GetJobSeekerById(int jobseeker_id);
    IEnumerable<JobSeeker> GetAllJobSeekers();
}