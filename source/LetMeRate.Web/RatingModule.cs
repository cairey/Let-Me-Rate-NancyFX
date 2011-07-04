﻿using System;
using System.Collections.Generic;
using System.Web;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using LetMeRate.Application.Services;
using Nancy;
using System.Linq;

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
                                             return this.AsJsonRatings(ratings);
                                         };


            Get["/{Key}/Ratings/Custom"] = x =>
                                               {
                                                   Dictionary<string, object>.KeyCollection keys = Request.Query.GetDynamicMemberNames();
                                                   var customParam = keys.First();
                                                   var queryParam = Request.Query[customParam];

                                                   var query = new GetRatingsCustomParamQuery(new AccountContext(x.Key), customParam, queryParam);
                                                   var ratings = _ratingService.GetRatingsByCustomParam(query);
                                                   return this.AsJsonRatings(ratings);
                                               };



            Get["/{Key}/Ratings/Between/Rating"] = x =>
                                        {

                                            var query = new GetRatingsBetweenRatingQuery(new AccountContext(x.Key), Request.Query.minRating, Request.Query.maxRating);
                                            var ratings = _ratingService.GetRatingsBetweenRating(query);
                                            return this.AsJsonRatings(ratings);
                                        };




        }



        private Response AsJsonRatings(dynamic ratings)
        {
            var ratingsList = new List<object>();
            foreach (var rating in ratings)
                ratingsList.Add(new { rating.Rating, rating.CustomParams });

            return Response.AsJson(ratingsList);
        }

    }
}