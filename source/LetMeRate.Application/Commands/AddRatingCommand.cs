using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class AddRatingCommand : WithAccountContext
    {
        private readonly uint _rating;
        private readonly string _customParams;

        public AddRatingCommand(uint rating, string customParams, AccountContext accountContext)
            : base(accountContext)
        {
            _rating = rating;
            _customParams = customParams;
        }


        public string CustomParams
        {
            get { return _customParams; }
        }

        public uint Rating
        {
            get { return _rating; }
        }
    }
}
