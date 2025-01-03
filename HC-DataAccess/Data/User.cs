using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? RoleId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Gender { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<UserPatient> UserPatients { get; set; } = new List<UserPatient>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
