using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingsBetweenRatingQuery : WithAuthorisationContext
    {
        private readonly int minRating;
        private readonly int maxRating;

        public GetRatingsBetweenRatingQuery(AuthorisationContext authorisationContext, int minRating, int maxRating)
            : base(authorisationContext)
        {
            this.minRating = minRating;
            this.maxRating = maxRating;
        }

        public int MaxRating
        {
            get { return maxRating; }
        }

        public int MinRating
        {
            get { return minRating; }
        }
    }
}
