using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web
{
    public class LetMeRateModule : NancyModule
    {
        protected Response AsJsonRatings(dynamic ratings)
        {
            var ratingsList = new List<object>();
            foreach (var rating in ratings)
                ratingsList.Add(new { rating.Id, rating.Rating, rating.CustomParams });

            return Response.AsJson(ratingsList);
        }
    }
}