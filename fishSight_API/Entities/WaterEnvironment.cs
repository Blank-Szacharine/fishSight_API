using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class WaterEnvironment
{
    public int FishId { get; set; }

    public int WaterId { get; set; }

    public int Id { get; set; }

    public virtual Fish Fish { get; set; } = null!;

    public virtual WaterTbl Water { get; set; } = null!;
}
