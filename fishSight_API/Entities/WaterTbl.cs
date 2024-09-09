using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class WaterTbl
{
    public int Id { get; set; }

    public string WaterType { get; set; } = null!;

    public virtual ICollection<WaterEnvironment> WaterEnvironments { get; set; } = new List<WaterEnvironment>();
}
