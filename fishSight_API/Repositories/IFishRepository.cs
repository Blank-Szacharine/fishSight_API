using fishSight_API.Models;

namespace fishSight_API.Repositories
{
    public interface IFishRepository
    {
        Task<IEnumerable<Fish_complete>> GetFishAsync();
        Task<IEnumerable<envFish>> GetFishByEnv(int water_id);
        Task<Fish_complete> GetFishByIdAsync(int Id);
    }
}