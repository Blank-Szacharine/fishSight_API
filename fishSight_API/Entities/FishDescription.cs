using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class FishDescription
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public string Description { get; set; } = null!;

    public string Distribution { get; set; } = null!;

    public string Biology { get; set; } = null!;

    public string LifeCycle { get; set; } = null!;

    public virtual Fish Fish { get; set; } = null!;
}
