using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Fish
{
    public int FishId { get; set; }

    public string ScientificName { get; set; } = null!;

    public string GeneralName { get; set; } = null!;

    public byte[] FishImg { get; set; } = null!;

    public virtual ICollection<Environment> Environments { get; set; } = new List<Environment>();

    public virtual ICollection<FishDescription> FishDescriptions { get; set; } = new List<FishDescription>();

    public virtual ICollection<FishLength> FishLengths { get; set; } = new List<FishLength>();

    public virtual ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();

    public virtual ICollection<LocalName> LocalNames { get; set; } = new List<LocalName>();

    public virtual ICollection<WaterEnvironment> WaterEnvironments { get; set; } = new List<WaterEnvironment>();
}
