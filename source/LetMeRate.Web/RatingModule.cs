using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using LetMeRate.Application.Services;
using LetMeRate.Web.Helpers;
using Nancy;
using System.Linq;

namespace LetMeRate.Web
{
    public class RatingModule : LetMeRateModule
    {
        private readonly IRatingService ratingService;

        public RatingModule(IRatingService ratingService, IHttpContextAccessor httpContextAccessor)
        {
            this.ratingService = ratingService;


            Get["/"] = x =>
                           {
                return "Test Route";
            };

            Post["/{TokenKey}/Ratings"] = x =>
                                         {
                                            var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                                            var command = new AddRatingCommand(Request.Form.UniqueKey, uint.Parse(Request.Form.Rating), Request.Form.CustomParams, new AuthorisationContext(x.TokenKey, ipAddress));
                                            this.ratingService.AddRating(command);
                                            return Response.AsJson((string)Request.Form.UniqueKey);
                                        };

            
            Get["/{TokenKey}/Ratings/Key/{UniqueKey}"] = x =>
            {
                var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                var query = new GetRatingUniqueKeyQuery(new AuthorisationContext(x.TokenKey, ipAddress), x.UniqueKey);
                var ratings = ratingService.GetRatingsByUniqueKey(query);
                var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                return this.AsJsonRatings(ratings, ratingAverages);
            };


            Get["/{TokenKey}/Ratings/All"] = x =>
                                         {
                                             var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                                             var query = new GetAllRatingsQuery(new AuthorisationContext(x.TokenKey, ipAddress));
                                             var ratings = ratingService.GetAllRatings(query);
                                             var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                             return this.AsJsonRatings(ratings, ratingAverages);
                                         };


            Get["/{TokenKey}/Ratings/Custom"] = x =>
                                               {
                                                   var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                                                   Dictionary<string, object>.KeyCollection keys = Request.Query.GetDynamicMemberNames();
                                                   var customParam = keys.First();
                                                   var queryParam = Request.Query[customParam];

                                                   var query = new GetRatingsCustomParamQuery(new AuthorisationContext(x.TokenKey, ipAddress), customParam, queryParam);
                                                   var ratings = ratingService.GetRatingsByCustomParam(query);
                                                   var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                                   return this.AsJsonRatings(ratings, ratingAverages);
                                               };



            Get["/{TokenKey}/Ratings/Between/Rating"] = x =>
                                        {
                                            var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                                            var query = new GetRatingsBetweenRatingQuery(new AuthorisationContext(x.TokenKey, ipAddress), Request.Query.minRating, Request.Query.maxRating);
                                            var ratings = this.ratingService.GetRatingsBetweenRating(query);
                                            var ratingAverages = ratingService.GetAverageRatings(ratings.ToList());
                                            return this.AsJsonRatings(ratings, ratingAverages);
                                        };


            Delete["/{TokenKey}/Ratings/{UniqueKey}"] = x =>
                                                       {
                                                           var ipAddress = IPAddress.Parse(httpContextAccessor.Current.Request.UserHostAddress);
                                                           var command = new DeleteRatingCommand(new AuthorisationContext(x.TokenKey, ipAddress), x.UniqueKey);
                                                           return Response.AsJson((int)this.ratingService.DeleteRating(command));
                                                       };

            Put["/{Key}/Ratings/{UniqueKey}"] = x =>
                                                    {
                                                        return null; // TODO:need to update a rating by ID

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