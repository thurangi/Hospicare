using HC_DataAccess.Data;
using HC_DataAccess.Models;

namespace HC_DataAccess.Signin;

public class RegisterUserMain
{

    private readonly HCDbContext _hCDbContext;

    public RegisterUserMain(HCDbContext hCDbContext)
    {
        _hCDbContext = hCDbContext;

    }
    public async Task<User> RegisterUserAsync(RegisterModel model)
    {
        if (_hCDbContext.Users.Any(x => x.Username == model.UserName))
            throw new Exception("Username '" + model.UserName + "' is already taken");

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        User user = new()
        {
            Username = model.UserName,
            PasswordHash = passwordHash,
            Email = model.Email,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            IsActive = true,
            RoleId = 1,
            Gender = model.Gender,
            CreatedDate = DateTime.Now
        };
        _hCDbContext.Users.Add(user);
        await _hCDbContext.SaveChangesAsync();
        return user;
    }

}
