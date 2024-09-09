using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class FishLength
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public string Maturity { get; set; } = null!;

    public string MaxLength { get; set; } = null!;

    public string Other { get; set; } = null!;

    public virtual Fish Fish { get; set; } = null!;
}
