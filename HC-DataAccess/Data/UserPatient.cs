using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class UserPatient
{
    public int UserPatientId { get; set; }

    public int? UserId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual User? User { get; set; }
}
