using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? Department { get; set; }

    public string? Doctor { get; set; }

    public string? ReasonForVisit { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<UserRoles> MedicalRecords { get; set; } = new List<UserRoles>();

    public virtual Patient? Patient { get; set; }
}
