using fishSight_API.Entities;
using fishSight_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static fishSight_API.Models.envFish;
using static fishSight_API.Models.Fish_complete;

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
                Fish_Id = envFish.WaterEnvironments.FirstOrDefault().Fish.FishId,
                water_id = water_id
            };
            fish.Add(f);
        }

        return fish;

    }


    public async Task<IEnumerable<shortModel>> GetFishByReg(string region)
    {
        var fishList = await _ctx.Regions
            .Where(r => r.RegionName == region)
            .Include(r => r.Environments)
                .ThenInclude(e => e.Fish)
                    .ThenInclude(f => f.FishDescriptions)
            .SelectMany(r => r.Environments.Select(e => e.Fish))
            .ToListAsync();

        var fish = new List<shortModel>();
        foreach (var fsh in fishList)
        {
            var f = new shortModel
            {
                fish_id = fsh.FishId, 
                Fish_name = fsh.GeneralName,
                Scientific_name = fsh.ScientificName,
                fish_img = fsh.FishImg,
                Fish_Description = fsh.FishDescriptions.FirstOrDefault()?.Description
            };
            fish.Add(f);
        }

        return fish;
    }


    public async Task<IEnumerable<Fish_complete>> GetFishAsync()
    {

        var fishes = await _ctx.Fish.Include(x => x.FishDescriptions)
                            .ThenInclude(y => y.FishFamilyNavigation)
                            .Include(x => x.FishLengths)
                            .Include(x => x.LocalNames)
                            .Include(x =>x.WaterEnvironments)
                            .Include(x => x.Environments)
                            .ThenInclude(x => x.Region)
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
                Fish_family = fsh.FishDescriptions.FirstOrDefault()?.FishFamilyNavigation.Family,
                family_id = fsh.FishDescriptions.FirstOrDefault()?.FishFamilyNavigation.Id,
                length_maturity = fsh.FishLengths.FirstOrDefault()?.Maturity,
                length_maxLength = fsh.FishLengths.FirstOrDefault()?.MaxLength,
                Region_Name =fsh.Environments.Select(e => new Fish_complete.Region_Names
                {
                    Region_Id = e.Region.RegionId,
                    Region = e.Region.RegionName
                })
                    .ToList(),
                other = fsh.FishLengths.FirstOrDefault()?.Other,
                Water_Environment = _ctx.WaterTbls
                                    .Include(x=>x.WaterEnvironments)
                                    .Where( x=>x.WaterEnvironments.Any(x=>x.FishId == fsh.FishId))
                                    .Select(waterTbl => new Water_Environments
                                    {
                                       
                                        Water_Id = waterTbl.Id, 
                                        Water = waterTbl.WaterType, 
                                                                       
                                    })
                                    .ToList(),
            };

            fish.Add(completeFish);
        }


        return fish;
    }

    public async Task<Fish_complete> GetFishByIdAsync(int Id)
    {

        var fish = await _ctx.Fish
                           .Include(x => x.FishLengths)
                           .Include(x => x.LocalNames)
                           .Include(x => x.Environments)
                            .ThenInclude(x =>x.Region)
                           .Include(x => x.FishDescriptions)
                                .ThenInclude(fd => fd.FishFamilyNavigation)
                           .SingleOrDefaultAsync(f => f.FishId == Id);

        
        if (fish == null)
        {
            return null;
        }

       
        var completeFish = new Fish_complete
        {
            Id = fish.FishId,
            Fish_name = fish.GeneralName,
            Scientific_name = fish.ScientificName,
            fish_img = fish.FishImg,
            family_id = fish.FishDescriptions.FirstOrDefault().FishFamilyNavigation.Id,
            Fish_family = fish.FishDescriptions.FirstOrDefault().FishFamilyNavigation.Family,
            Fish_Description = fish.FishDescriptions.FirstOrDefault()?.Description,
            Fish_biology = fish.FishDescriptions.FirstOrDefault()?.Biology,
            Lifecycle = fish.FishDescriptions.FirstOrDefault()?.LifeCycle,
            length_maturity = fish.FishLengths.FirstOrDefault()?.Maturity,
            length_maxLength = fish.FishLengths.FirstOrDefault()?.MaxLength,
            other = fish.FishLengths.FirstOrDefault()?.Other,
            Region_Name = fish.Environments
                    .Select(e => new Fish_complete.Region_Names
                    {
                        Region_Id = e.Region.RegionId,
                        Region = e.Region.RegionName
                    })
                    .ToList(),
            Water_Environment = _ctx.WaterTbls
                                    .Include(x => x.WaterEnvironments)
                                    .Where(x => x.WaterEnvironments.Any(x => x.FishId == fish.FishId))
                                    .Select(waterTbl => new Water_Environments
                                    {

                                        Water_Id = waterTbl.Id,
                                        Water = waterTbl.WaterType,

                                    })
                                    .ToList(),
        };

       
        return completeFish;

    }


    public async Task<envFish> GetFishByNameAsync(string Id)
    {
        var fish = await _ctx.Fish
            .Include(x => x.FishDescriptions)
            .Include(x =>x.Environments)
            .ThenInclude(x =>x.Region)
            .SingleOrDefaultAsync(f => f.GeneralName == Id);

        if (fish == null)
        {
            return null; 
        }

        
        var envFish = new envFish
        {
            fish_img = fish.FishImg,
            Fish_Name = fish.GeneralName,
            Scientific_Name = fish.ScientificName,
            Fish_Description = fish.FishDescriptions.FirstOrDefault()?.Description,
            Fish_Id = fish.FishId,
           

        };

        return envFish; 
    }

    public async Task<IEnumerable<shortModel>> GetFishByFam(int family_id)
    {
        var test = await _ctx.FishFamilies.ToListAsync();
        var fishDescriptions = await _ctx.FishFamilies
            .Where(x => x.Id == family_id)
            .Include(x => x.FishDescriptions)
                .ThenInclude(fd => fd.Fish) 
            .ToListAsync();

        var fish = new List<shortModel>();

        foreach (var family in fishDescriptions)
        {
            foreach (var fd in family.FishDescriptions)
            {
                var f = new shortModel
                {
                    fish_id = fd.Fish.FishId,
                    Fish_name = fd.Fish.GeneralName,
                    Scientific_name = fd.Fish.ScientificName,
                    fish_img = fd.Fish.FishImg,
                    Fish_Description = fd.Description,
                    family_id = family.Id,
                    family = family.Family,
                };
                fish.Add(f);
            }
        }

        return fish;
    }

    public async Task<List<envFish>> GetFishByNameallAsync()
    {
        var fishList = await _ctx.Fish
            .Include(x => x.FishDescriptions)
            .ToListAsync();

        if (fishList == null || !fishList.Any())
        {
            return null; 
        }

        var allfishname = new List<envFish>();

        foreach (var fish in fishList)
        {
            var envFish = new envFish
            {
                fish_img = fish.FishImg,
                Fish_Name = fish.GeneralName,
                Scientific_Name = fish.ScientificName,
                Fish_Description = fish.FishDescriptions.FirstOrDefault()?.Description,
                Fish_Id = fish.FishId,
            };

            allfishname.Add(envFish);
        }

        return allfishname;
    }

}



