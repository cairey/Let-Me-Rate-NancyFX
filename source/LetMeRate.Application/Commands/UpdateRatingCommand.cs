using System;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class UpdateRatingCommand : WithAccountContext
    {
        private readonly string _uniqueKey;
        private readonly uint? _rating;
        private readonly string _customParams;

        public UpdateRatingCommand(string uniqueKey, uint? rating, string customParams, AccountContext accountContext)
            : base(accountContext)
        {
            _uniqueKey = uniqueKey;
            _rating = rating;
            _customParams = customParams;
        }

        public string CustomParams
        {
            get { return _customParams; }
        }

        public uint? Rating
        {
            get { return _rating; }
        }

        public string UniqueKey
        {
            get { return _uniqueKey; }
        }
    }
}