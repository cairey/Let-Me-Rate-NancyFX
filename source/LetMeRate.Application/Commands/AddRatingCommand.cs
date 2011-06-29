namespace LetMeRate.Application.Commands
{
    public class AddRatingCommand
    {
        private readonly uint _rating;
        private readonly string _customParams;
        private readonly string _accountKey;

        public AddRatingCommand(uint rating, string customParams, string accountKey)
        {
            _rating = rating;
            _customParams = customParams;
            _accountKey = accountKey;
        }

        public string AccountKey
        {
            get { return _accountKey; }
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
