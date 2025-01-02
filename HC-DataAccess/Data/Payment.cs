using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? BillingId { get; set; }

    public int? PatientId { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? Status { get; set; }

    public string? TransactionId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public virtual Billing? Billing { get; set; }

    public virtual Patient? Patient { get; set; }
}
