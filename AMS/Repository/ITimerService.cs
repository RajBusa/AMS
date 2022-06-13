namespace AMS.Repository
{
    public interface ITimerService
    {
        Task<IEnumerable<int>> AddDate();
    }
}