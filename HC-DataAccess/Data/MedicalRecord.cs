using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PatientId { get; set; }

    public int? VisitId { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public string? Prescription { get; set; }

    public DateOnly? PrescriptionExpiry { get; set; }

    public string? Allergies { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

    public virtual Patient? Patient { get; set; }

    public virtual Appointment? Visit { get; set; }
}
