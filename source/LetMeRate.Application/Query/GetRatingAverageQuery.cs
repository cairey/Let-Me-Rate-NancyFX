using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingAverageQuery : WithAccountContext
    {
        private readonly string uniqueKey;

        public GetRatingAverageQuery(AccountContext accountContext, string uniqueKey) : base(accountContext)
        {
            this.uniqueKey = uniqueKey;
        }

        public string UniqueKey
        {
            get { return uniqueKey; }
        }
    }
}