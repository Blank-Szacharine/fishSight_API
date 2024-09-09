using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Environment
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public int MunicipalityId { get; set; }

    public virtual Fish Fish { get; set; } = null!;

    public virtual Municipality Municipality { get; set; } = null!;
}
