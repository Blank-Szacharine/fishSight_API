using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class LocalName
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public string LocalName1 { get; set; } = null!;

    public virtual Fish Fish { get; set; } = null!;
}
