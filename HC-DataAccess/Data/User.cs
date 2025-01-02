using System;
using System.Collections.Generic;

namespace HC_DataAccess.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? RoleId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserPatient> UserPatients { get; set; } = new List<UserPatient>();
}
