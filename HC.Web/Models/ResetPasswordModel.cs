namespace HC.Web.Models;



public class ResetPasswordModel
{
    public string Password { get; set; } = string.Empty;
    public string OldPassword { get; set; } = string.Empty;
}
