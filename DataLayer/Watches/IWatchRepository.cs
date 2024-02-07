// IWatchRepository.cs
namespace DataLayer.Watches;

public interface IWatchRepository
{
    Task<List<WatchModel>> GetAllClocksAsync();
    Task<int> AddClockAsync(WatchModel watch);
}