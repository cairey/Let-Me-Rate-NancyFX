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

            Post["/{Key}/Ratings"] = x =>
                                        {
                                            var command = new AddRatingCommand(uint.Parse(Request.Form.Rating), Request.Form.CustomParams, new AccountContext(x.Key));
                                            _ratingService.AddRating(command);

                                            return "Test";
                                        };


            Get["/{Key}/Ratings/All"] = x =>
                                         {
                                             var query = new GetAllRatingsQuery(new AccountContext(x.Key));
                                             var ratings = _ratingService.GetAllRatings(query);

                                             var ratingsList = new List<object>();
                                             foreach (var rating in ratings)
                                                 ratingsList.Add(new { rating.Rating, rating.CustomParams });

                                             return Response.AsJson(ratingsList);
                                         };


            Get["/{Key}/Ratings/Between/Rating"] = x =>
                                        {

                                            var query = new GetRatingsBetweenRatingQuery(new AccountContext(x.Key), Request.Query.minRating, Request.Query.maxRating);
                                            var ratings = _ratingService.GetRatingsBetweenRating(query);

                                            var ratingsList = new List<object>();
                                            foreach (var rating in ratings)
                                                ratingsList.Add(new { rating.Rating, rating.CustomParams });

                                            return Response.AsJson(ratingsList);
                                        };

        }


    }
}