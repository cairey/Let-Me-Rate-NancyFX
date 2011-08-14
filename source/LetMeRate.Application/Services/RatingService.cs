using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using LetMeRate.Common;
using Simple.Data;

namespace LetMeRate.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IAccountService accountService;
        private readonly IAuthorisationService authorisationService;

        public RatingService(IAccountService accountService, IAuthorisationService authorisationService)
        {
            this.accountService = accountService;
            this.authorisationService = authorisationService;
        }

        public dynamic AddRating(AddRatingCommand command)
        {
            var userAccount = GetUserAccount(command.AuthorisationContext);

            if (command.Rating > userAccount.RateOutOf)
                throw new Exception("You cannot rate higher than the setting set by your account.");

            var db = Database.Open();
            return db.Ratings.Insert(Id: Guid.NewGuid(),
                                            UserAccountId: userAccount.Id,
                                            UniqueKey: command.UniqueKey,
                                            CustomParams: command.CustomParams,
                                            Rating: (int)command.Rating);
        }

        public dynamic GetAllRatings(GetAllRatingsQuery query)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(query.AuthorisationContext);
            return db.Ratings.FindAllByUserAccountId(userAccount.Id);
        }

        public IDictionary<string, int> GetAverageRatings(IEnumerable<dynamic> ratings)
        {
            var distinctAverageRatings = ratings.Select(x => x.UniqueKey).Distinct().ToDictionary(key => (string)key, value => 0);
            var uniqueKeys = distinctAverageRatings.Keys.ToList();

            foreach(var uniqueKey in uniqueKeys)
            {
                var sumOfRatings = ratings.Where(x => x.UniqueKey == uniqueKey).Sum(x => x.Rating);
                var totalCount = ratings.Where(x => x.UniqueKey == uniqueKey).Count();
                var meanAvg = sumOfRatings / totalCount;
                distinctAverageRatings[uniqueKey] = meanAvg;
            }

            return distinctAverageRatings;
        }

        public dynamic GetRatingsBetweenRating(GetRatingsBetweenRatingQuery query)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(query.AuthorisationContext);
            return db.Ratings.FindAll(db.Ratings.Rating >= query.MinRating
                && db.Ratings.Rating <= query.MaxRating
                && db.Ratings.UserAccountId == userAccount.Id);
        }

        
        public dynamic GetRatingsByCustomParam(GetRatingsCustomParamQuery query)
        {
            // open to sql injection
            var db = Database.Open();
            var userAccount = GetUserAccount(query.AuthorisationContext);
            var like = "%" + query.CustomParam + "[\"''][:][ ][\"'']" + query.CustomQuery + "%";

            return db.Ratings.FindAll(db.Ratings.CustomParams.Like(like) && db.Ratings.UserAccountId == userAccount.Id);
        }

        public dynamic GetRatingsByUniqueKey(GetRatingUniqueKeyQuery query)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(query.AuthorisationContext);

            return db.ratings.FindAll(db.Ratings.UniqueKey == query.UniqueKey
                                                && db.Ratings.UserAccountId == userAccount.Id);
        }

        public dynamic DeleteRating(DeleteRatingCommand command)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(command.AuthorisationContext);
            var ratings = db.ratings.FindAll(db.Ratings.UniqueKey == command.UniqueKey
                                    && db.Ratings.UserAccountId == userAccount.Id);

            if (!ratings.Any())
                return 0;

            foreach(var rating in ratings)
                db.Ratings.DeleteById(rating.Id);

            return 1;
        }

        [Obsolete]
        public dynamic UpdateRating(UpdateRatingCommand command)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(command.AccountContext.AccountKey);
            var ratings = db.ratings.FindAll(db.Ratings.UniqueKey == command.UniqueKey
                        && db.Ratings.UserAccountId == userAccount.Id);

            var rating = ratings.FirstOrDefault();
            if (rating == null) return 0;

            if(command.Rating.IsNotNull())
                rating.Rating = command.Rating;

            if (command.CustomParams.IsNotNull())
                rating.CustomParams = command.CustomParams;

            return db.ratings.Update(rating);
        }

        private dynamic GetUserAccount(AuthorisationContext authorisationContext)
        {
            var authorisation = authorisationService.GetAuthorsation(new GetAuthorisationQuery(authorisationContext));
            return accountService.GetUserAccount(new GetUserAccountQuery(authorisation.UserAccountId));
        }

        private dynamic GetUserAccount(string accountKey)
        {
            return accountService.GetUserAccountByKey(new GetUserAccountByKeyQuery(new AccountContext(accountKey)));
        }
    }
}
