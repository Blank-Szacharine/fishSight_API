using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Province
{
    public int RegionId { get; set; }

    public int ProvinceId { get; set; }

    public string ProvinceName { get; set; } = null!;

    public virtual ICollection<Municipality> Municipalities { get; set; } = new List<Municipality>();

    public virtual Region Region { get; set; } = null!;
}
