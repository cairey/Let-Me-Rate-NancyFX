using LetMeRate.Application.Commands;

namespace LetMeRate.Application.Services
{
    public interface IAccountService
    {
        void CreateAccount(AddAccountCommand addAccountCommand);
    }
}
