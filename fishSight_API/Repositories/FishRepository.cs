using fishSight_API.Entities;
using fishSight_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishSight_API.Repositories;

public class FishRepository : IFishRepository
{
    private readonly FinsapContext _ctx;
    public FishRepository(FinsapContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<envFish>> GetFishByEnv(int water_id)
    {


        var fishes = await _ctx.Fish
                        .Include(x => x.FishDescriptions)
                        .Include(x => x.WaterEnvironments)
                         .Where(x => x.WaterEnvironments.Any(we => we.WaterId == water_id))
                        .ToListAsync();

        var fish = new List<envFish>();

        foreach (var envFish in fishes)
        {
            var f = new envFish
            {
                fish_img = envFish.WaterEnvironments.FirstOrDefault().Fish.FishImg,
                Fish_Name = envFish.WaterEnvironments.FirstOrDefault().Fish.GeneralName,
                Scientific_Name = envFish.WaterEnvironments.FirstOrDefault().Fish.ScientificName,
                Fish_Description = envFish.WaterEnvironments.FirstOrDefault().Fish.FishDescriptions.FirstOrDefault().Description,
                Fish_Id = envFish.WaterEnvironments.FirstOrDefault().Fish.FishId
            };
            fish.Add(f);
        }

        return fish;

    }

    public async Task<IEnumerable<Fish_complete>> GetFishAsync()
    {

        var fishes = await _ctx.Fish.Include(x => x.FishDescriptions)
                            .Include(x => x.FishLengths)
                            .Include(x => x.LocalNames)
                            .Include(x => x.Environments)
                            .ToListAsync();


        var fish = new List<Fish_complete>();


        foreach (var fsh in fishes)
        {
            var completeFish = new Fish_complete
            {
                Id = fsh.FishId,
                Fish_name = fsh.GeneralName,
                Scientific_name = fsh.ScientificName,
                fish_img = fsh.FishImg,
                Fish_Description = fsh.FishDescriptions.FirstOrDefault()?.Description,
                Fish_biology = fsh.FishDescriptions.FirstOrDefault()?.Biology,
                Lifecycle = fsh.FishDescriptions.FirstOrDefault()?.LifeCycle,
                length_maturity = fsh.FishLengths.FirstOrDefault()?.Maturity,
                length_maxLength = fsh.FishLengths.FirstOrDefault()?.MaxLength,
                other = fsh.FishLengths.FirstOrDefault()?.Other,
            };

            fish.Add(completeFish);
        }


        return fish;
    }

    public async Task<Fish_complete> GetFishByIdAsync(int Id)
    {

        var fish = await _ctx.Fish.Include(x => x.FishDescriptions)
                           .Include(x => x.FishLengths)
                           .Include(x => x.LocalNames)
                           .Include(x => x.Environments)
                           .SingleOrDefaultAsync(f => f.FishId == Id);

        // If no fish is found, return null or handle accordingly
        if (fish == null)
        {
            return null;
        }

        // Create a completeFish object from the fetched data
        var completeFish = new Fish_complete
        {
            Id = fish.FishId,
            Fish_name = fish.GeneralName,
            Scientific_name = fish.ScientificName,
            fish_img = fish.FishImg,
            Fish_Description = fish.FishDescriptions.FirstOrDefault()?.Description,
            Fish_biology = fish.FishDescriptions.FirstOrDefault()?.Biology,
            Lifecycle = fish.FishDescriptions.FirstOrDefault()?.LifeCycle,
            length_maturity = fish.FishLengths.FirstOrDefault()?.Maturity,
            length_maxLength = fish.FishLengths.FirstOrDefault()?.MaxLength,
            other = fish.FishLengths.FirstOrDefault()?.Other,
        };

        // Return the constructed Fish_complete object
        return completeFish;

    }

}



