using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IAccountService
    {
        dynamic CreateAccount(AddUserAccountCommand addUserAccountCommand);
        dynamic GetUserAccountByKey(GetAccountQuery getAccountQuery);
        dynamic ValidateAccount(ValidateAccountCommand command);
    }
}
