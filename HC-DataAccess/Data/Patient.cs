using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Patient
{
    public int PatientId { get; set; }

    public bool? HasInsurance { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UserId { get; set; }

    public string? Diagnosis { get; set; }

    public string? EmergencyContact { get; set; }

    public string? InsuranceProvider { get; set; }

    public string? PolicyNumber { get; set; }

    public string? InsuranceNumber { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<InsuranceCoverage> InsuranceCoverages { get; set; } = new List<InsuranceCoverage>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }

    public virtual ICollection<UserPatient> UserPatients { get; set; } = new List<UserPatient>();
}
