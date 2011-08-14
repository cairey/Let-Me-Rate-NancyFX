using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IAccountService
    {
        dynamic CreateAccount(AddUserAccountCommand query);
        dynamic GetUserAccountByKey(GetUserAccountByKeyQuery query);
        dynamic ValidateAccount(ValidateAccountCommand command);
        dynamic GetUserAccount(GetUserAccountQuery query);
    }
}
