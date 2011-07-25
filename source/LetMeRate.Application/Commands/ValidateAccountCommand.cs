namespace LetMeRate.Application.Commands
{
    public class ValidateAccountCommand
    {
        private readonly string validationKey;

        public ValidateAccountCommand(string validationKey)
        {
            this.validationKey = validationKey;
        }

        public string ValidationKey
        {
            get { return validationKey; }
        }
    }
}