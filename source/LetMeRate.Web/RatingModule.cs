using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using LetMeRate.Application.Services;
using Nancy;

namespace LetMeRate.Web
{
    public class RatingModule : NancyModule
    {
        private readonly IRatingService _ratingService;

        public RatingModule(IRatingService ratingService)
        {
            _ratingService = ratingService;


            Get["/"] = x =>
            {
                return "Test Route";
            };

            Post["/{Key}/Rate"] = x =>
                                        {
                                            var command = new AddRatingCommand(uint.Parse(Request.Form.Rating), Request.Form.CustomParams, new AccountContext(x.Key));
                                            _ratingService.AddRating(command);

                return "Test";
            };


            Post["/{Key}/Ratings"] = x =>
                                         {
                                             var query = new GetRatingsQuery(new AccountContext(x.Key));

                                             _ratingService.GetRatings(query);
                
                return "Test";
            };

        }        


    }
}