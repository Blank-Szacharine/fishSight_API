using System;
using System.Collections.Generic;

namespace fishSight_API.Entities;

public partial class Municipality
{
    public int ProvinceId { get; set; }

    public int MunicipalityId { get; set; }

    public string MunicipalityName { get; set; } = null!;

    public virtual ICollection<Environment> Environments { get; set; } = new List<Environment>();

    public virtual Province Province { get; set; } = null!;
}
