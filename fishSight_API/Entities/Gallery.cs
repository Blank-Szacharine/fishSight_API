using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Gallery
{
    public int Id { get; set; }

    public int FishId { get; set; }

    public byte[] FishImg { get; set; } = null!;

    public virtual Fish Fish { get; set; } = null!;
}
