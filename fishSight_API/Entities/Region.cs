using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionName { get; set; } = null!;

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
}
