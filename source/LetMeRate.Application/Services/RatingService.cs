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

        public RatingService(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public dynamic AddRating(AddRatingCommand addRatingCommand)
        {
            var userAccount = GetUserAccount(addRatingCommand.AccountContext.AccountKey);

            if (addRatingCommand.Rating > userAccount.RateOutOf)
                throw new Exception("You cannot rate higher than the setting set by your account.");

            var db = Database.Open();
            return db.Ratings.Insert(Id: Guid.NewGuid(),
                                            UserAccountId: userAccount.Id,
                                            UniqueKey: addRatingCommand.UniqueKey,
                                            CustomParams: addRatingCommand.CustomParams,
                                            Rating: (int)addRatingCommand.Rating);
        }

        public dynamic GetAllRatings(GetAllRatingsQuery getAllRatingsQuery)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(getAllRatingsQuery.AccountContext.AccountKey);
            return db.Ratings.FindAllByUserAccountId(userAccount.Id);
        }

        public IDictionary<string, int> GetAverageRatings(IEnumerable<dynamic> ratings)
        {
            var distinctAverageRatings = ratings.Select(x => x.UniqueKey).Distinct().ToDictionary(key => (string)key, value => 0);
            var uniqueKeys = distinctAverageRatings.Keys.ToList();

            foreach (var uniqueKey in uniqueKeys)
            {
                var sumOfRatings = ratings.Where(x => x.UniqueKey == uniqueKey).Sum(x => x.Rating);
                var totalCount = ratings.Where(x => x.UniqueKey == uniqueKey).Count();
                var meanAvg = sumOfRatings / totalCount;
                distinctAverageRatings[uniqueKey] = meanAvg;
            }

            return distinctAverageRatings;
        }

        public dynamic GetRatingsBetweenRating(GetRatingsBetweenRatingQuery getRatingsBetweenRatingQuery)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(getRatingsBetweenRatingQuery.AccountContext.AccountKey);
            return db.Ratings.FindAll(db.Ratings.Rating >= getRatingsBetweenRatingQuery.MinRating
                && db.Ratings.Rating <= getRatingsBetweenRatingQuery.MaxRating
                && db.Ratings.UserAccountId == userAccount.Id);
        }

        
        public dynamic GetRatingsByCustomParam(GetRatingsCustomParamQuery getRatingsCustomParamQuery)
        {
            // open to sql injection
            var db = Database.Open();
            var userAccount = GetUserAccount(getRatingsCustomParamQuery.AccountContext.AccountKey);
            var like = "%" + getRatingsCustomParamQuery.CustomParam + "[\"''][:][ ][\"'']" + getRatingsCustomParamQuery.CustomQuery + "%";

            return db.Ratings.FindAll(db.Ratings.CustomParams.Like(like) && db.Ratings.UserAccountId == userAccount.Id);
        }

        public dynamic GetRatingsByUniqueKey(GetRatingUniqueKeyQuery getRatingUniqueKeyQuery)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(getRatingUniqueKeyQuery.AccountContext.AccountKey);

            return db.ratings.FindAll(db.Ratings.UniqueKey == getRatingUniqueKeyQuery.UniqueKey
                                                && db.Ratings.UserAccountId == userAccount.Id);
        }

        public dynamic DeleteRating(DeleteRatingCommand command)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(command.AccountContext.AccountKey);
            var ratings = db.ratings.FindAll(db.Ratings.UniqueKey == command.UniqueKey
                                    && db.Ratings.UserAccountId == userAccount.Id);

            var rating = ratings.FirstOrDefault();
            if (rating == null) return 0;

            return db.Ratings.DeleteById(rating.Id);
        }

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

        private dynamic GetUserAccount(string accountKey)
        {
            return accountService.GetUserAccountByKey(new GetAccountQuery(new AccountContext(accountKey)));
        }
    }

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
