using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
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
            var userAccount = _accountService.GetUserAccountByKey(new GetAccountQuery(addRatingCommand.AccountKey));
            
            if (addRatingCommand.Rating > userAccount.RateOutOf)
                throw new Exception("You cannot rate higher than the setting set by your account.");


            var db = Database.Open();
            var rating = db.Rating.Insert(Id: Guid.NewGuid(),
                                            UserAccountId: userAccount.Id,
                                            CustomParams: addRatingCommand.CustomParams,
                                            Rating: (int)addRatingCommand.Rating);
        }

    }
}
