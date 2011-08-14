using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class AddRatingCommand : WithAuthorisationContext
    {
        private readonly string uniqueKey;
        private readonly uint rating;
        private readonly string customParams;

        public AddRatingCommand(string uniqueKey, uint rating, string customParams, AuthorisationContext authorisationContext)
            : base(authorisationContext)
        {
            this.uniqueKey = uniqueKey;
            this.rating = rating;
            this.customParams = customParams;
        }


        public string UniqueKey
        {
            get { return uniqueKey; }
        }

        public string CustomParams
        {
            get { return customParams; }
        }

        public uint Rating
        {
            get { return rating; }
        }
    }
}
