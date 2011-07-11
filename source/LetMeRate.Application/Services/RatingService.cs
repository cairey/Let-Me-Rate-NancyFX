using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using Simple.Data;

namespace LetMeRate.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IAccountService _accountService;

        public RatingService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void AddRating(AddRatingCommand addRatingCommand)
        {
            var userAccount = GetUserAccount(addRatingCommand.AccountContext.AccountKey);

            if (addRatingCommand.Rating > userAccount.RateOutOf)
                throw new Exception("You cannot rate higher than the setting set by your account.");


            var db = Database.Open();
            var rating = db.Ratings.Insert(Id: Guid.NewGuid(),
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

            return db.Ratings.FindAll(db.Ratings.CustomParams.Like(like)
                                        && db.Ratings.UserAccountId == userAccount.Id);
        }

        public dynamic GetRatingByUniqueKey(GetRatingUniqueKeyQuery getRatingUniqueKeyQuery)
        {
            var db = Database.Open();
            var userAccount = GetUserAccount(getRatingUniqueKeyQuery.AccountContext.AccountKey);

            return db.ratings.FindAll(db.Ratings.UniqueKey == getRatingUniqueKeyQuery.UniqueKey
                                                && db.Ratings.UserAccountId == userAccount.Id);
        }

        private dynamic GetUserAccount(string accountKey)
        {
            return _accountService.GetUserAccountByKey(new GetAccountQuery(new AccountContext(accountKey)));
        }
    }
}
