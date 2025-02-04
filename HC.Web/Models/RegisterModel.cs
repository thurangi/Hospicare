using System.ComponentModel.DataAnnotations;

namespace HC.Web.Models;

public class RegisterModel
{
    public Guid Id { get; set; }

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string ConfirmPassword { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;

    public int RoleID { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

}
