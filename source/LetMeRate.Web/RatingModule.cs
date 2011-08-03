using System;
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
    public class RatingModule : LetMeRateModule
    {
        private readonly IRatingService ratingService;

        public RatingModule(IRatingService ratingService)
        {
            this.ratingService = ratingService;


            Get["/"] = x =>
            {
                return "Test Route";
            };

            Post["/{Key}/Ratings"] = x =>
                                        {
                                            var command = new AddRatingCommand(Request.Form.UniqueKey, uint.Parse(Request.Form.Rating), Request.Form.CustomParams, new AccountContext(x.Key));
                                            this.ratingService.AddRating(command);
                                            return Response.AsJson((string)Request.Form.UniqueKey);
                                        };

            
            Get["/{Key}/Ratings/Key/{UniqueKey}"] = x =>
            {
                var query = new GetRatingUniqueKeyQuery(new AccountContext(x.Key), x.UniqueKey);
                var ratings = ratingService.GetRatingsByUniqueKey(query);
                var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                return this.AsJsonRatings(ratings, ratingAverages);
            };


            Get["/{Key}/Ratings/All"] = x =>
                                         {
                                             var query = new GetAllRatingsQuery(new AccountContext(x.Key));
                                             var ratings = ratingService.GetAllRatings(query);
                                             var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                             return this.AsJsonRatings(ratings, ratingAverages);
                                         };


            Get["/{Key}/Ratings/Custom"] = x =>
                                               {
                                                   Dictionary<string, object>.KeyCollection keys = Request.Query.GetDynamicMemberNames();
                                                   var customParam = keys.First();
                                                   var queryParam = Request.Query[customParam];

                                                   var query = new GetRatingsCustomParamQuery(new AccountContext(x.Key), customParam, queryParam);
                                                   var ratings = ratingService.GetRatingsByCustomParam(query);
                                                   var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                                   return this.AsJsonRatings(ratings, ratingAverages);
                                               };



            Get["/{Key}/Ratings/Between/Rating"] = x =>
                                        {

                                            var query = new GetRatingsBetweenRatingQuery(new AccountContext(x.Key), Request.Query.minRating, Request.Query.maxRating);
                                            var ratings = this.ratingService.GetRatingsBetweenRating(query);
                                            var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                            return this.AsJsonRatings(ratings, ratingAverages);
                                        };


            Delete["/{Key}/Ratings/{UniqueKey}"] = x =>
                                                       {
                                                           var command = new DeleteRatingCommand(new AccountContext(x.Key), x.UniqueKey);
                                                           return Response.AsJson((int)this.ratingService.DeleteRating(command));
                                                       };

            Put["/{Key}/Ratings/{UniqueKey}"] = x =>
                                                    {
                                                        string customParams = null;
                                                        if(Request.Form.CustomParams.HasValue)
                                                            customParams = Request.Form.CustomParams;

                                                        uint? rating = null;
                                                        if(Request.Form.Rating.HasValue)
                                                            rating = uint.Parse(Request.Form.Rating);
                                                        
                                                        var command = new UpdateRatingCommand(x.UniqueKey, rating, customParams, new AccountContext(x.Key));
                                                        return Response.AsJson((int)this.ratingService.UpdateRating(command));
                                                    };
        }





    }
}