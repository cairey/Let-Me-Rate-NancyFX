using LetMeRate.Application.Commands;

namespace LetMeRate.Application.Services
{
    public interface IAccountService
    {
        dynamic CreateAccount(AddUserAccountCommand addUserAccountCommand);
        dynamic GetUserAccountByKey(string accountKey);
    }
}
