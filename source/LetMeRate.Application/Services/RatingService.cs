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
            var userAccount = _accountService.GetUserAccountByKey(new GetAccountQuery(new AccountContext(addRatingCommand.AccountContext.AccountKey)));
            
            if (addRatingCommand.Rating > userAccount.RateOutOf)
                throw new Exception("You cannot rate higher than the setting set by your account.");


            var db = Database.Open();
            var rating = db.Ratings.Insert(Id: Guid.NewGuid(),
                                            UserAccountId: userAccount.Id,
                                            CustomParams: addRatingCommand.CustomParams,
                                            Rating: (int)addRatingCommand.Rating);
        }

        public dynamic GetAllRatings(GetAllRatingsQuery getAllRatingsQuery)
        {
            var db = Database.Open();
            var userAccount = _accountService.GetUserAccountByKey(new GetAccountQuery(new AccountContext(getAllRatingsQuery.AccountContext.AccountKey)));
            return db.Ratings.FindAllByUserAccountId(userAccount.Id);
        }

    }
}
