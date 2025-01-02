using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Billing
{
    public int BillingId { get; set; }

    public int? PatientId { get; set; }

    public int? AppointmentId { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? Status { get; set; }

    public string? TransactionId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
