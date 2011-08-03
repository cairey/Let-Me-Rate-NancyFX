using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web
{
    public class LetMeRateModule : NancyModule
    {
        protected Response AsJsonRatings(dynamic ratings)
        {
            var ratingsList = new List<dynamic>();
            foreach (var rating in ratings)
                ratingsList.Add(new { rating.UniqueKey, rating.Rating, rating.CustomParams });

            return Response.AsJson(ratingsList);
        }


        protected Response AsJsonRatings(dynamic ratings, IDictionary<string, int> averages)
        {
            dynamic expando = new ExpandoObject();
            expando.Ratings = new List<dynamic>();
            expando.Averages = averages;

            foreach(var rating in ratings)
                expando.Ratings.Add(new { rating.UniqueKey, rating.Rating, rating.CustomParams });

            return Response.AsJson((object)expando);
        }
    }
}