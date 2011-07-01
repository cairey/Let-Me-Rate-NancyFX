using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingsBetweenRatingQuery : WithAccountContext
    {
        private readonly int _minRating;
        private readonly int _maxRating;

        public GetRatingsBetweenRatingQuery(AccountContext accountContext, int minRating, int maxRating) : base(accountContext)
        {
            _minRating = minRating;
            _maxRating = maxRating;
        }

        public int MaxRating
        {
            get { return _maxRating; }
        }

        public int MinRating
        {
            get { return _minRating; }
        }
    }
}
