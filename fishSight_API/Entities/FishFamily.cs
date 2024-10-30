using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class FishFamily
{
    public int Id { get; set; }

    public string Family { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<FishDescription> FishDescriptions { get; set; } = new List<FishDescription>();
}
