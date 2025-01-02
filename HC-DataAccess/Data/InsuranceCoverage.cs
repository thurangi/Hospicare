using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class InsuranceCoverage
{
    public int InsuranceId { get; set; }

    public int? PatientId { get; set; }

    public string ProviderName { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public string? CoverageDetails { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly ValidUntil { get; set; }

    public string? GroupNumber { get; set; }

    public string? ContactInfo { get; set; }

    public virtual Patient? Patient { get; set; }
}
