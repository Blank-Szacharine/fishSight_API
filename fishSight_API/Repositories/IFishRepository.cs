using fishSight_API.Models;

namespace fishSight_API.Repositories
{
    public interface IFishRepository
    {
        Task<IEnumerable<Fish_complete>> GetFishAsync();
        Task<IEnumerable<envFish>> GetFishByEnv(int water_id);
        Task<IEnumerable<shortModel>> GetFishByFam(int family_id);
        Task<Fish_complete> GetFishByIdAsync(int Id);
        Task<envFish> GetFishByNameAsync(string Id);
        Task<IEnumerable<shortModel>> GetFishByReg(int region_id);
    }
}