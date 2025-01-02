using HC_DataAccess.Models;

namespace HC_DataAccess.Signin;

public class GetUsersMain
{
    public void GetEntities(SigninModel signinModel, out string result)
    {
        string inputUsername = signinModel.UserName.ToLower();
        string inputPassword = signinModel.Password.ToLower();
        string storedUsername = "test".ToLower();
        string storedPassword = "test".ToLower();
        if (inputUsername == storedUsername && inputPassword == storedPassword)
        {
            result = "success";
        }

        result = "not success";
    }
}
