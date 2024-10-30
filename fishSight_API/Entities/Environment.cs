using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Environment
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public int? RegionId { get; set; }

    public virtual Fish Fish { get; set; } = null!;

    public virtual Region? Region { get; set; }
}
