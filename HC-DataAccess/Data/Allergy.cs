using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Allergy
{
    public int AllergyId { get; set; }

    public int? PatientId { get; set; }

    public string AllergyName { get; set; } = null!;

    public string? Severity { get; set; }

    public string? Reaction { get; set; }

    public virtual Patient? Patient { get; set; }
}
