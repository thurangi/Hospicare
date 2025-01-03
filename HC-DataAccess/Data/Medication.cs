using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Medication
{
    public int MedicationId { get; set; }

    public int? RecordId { get; set; }

    public string Name { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Frequency { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual UserRoles? Record { get; set; }
}
