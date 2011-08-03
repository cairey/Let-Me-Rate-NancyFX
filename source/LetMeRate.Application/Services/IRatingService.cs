using System.Collections.Generic;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IRatingService
    {
        dynamic AddRating(AddRatingCommand addRatingCommand);
        dynamic GetAllRatings(GetAllRatingsQuery getAllRatingsQuery);
        dynamic GetRatingsBetweenRating(GetRatingsBetweenRatingQuery getRatingsBetweenRatingQuery);
        dynamic GetRatingsByCustomParam(GetRatingsCustomParamQuery getRatingsCustomParamQuery);
        dynamic GetRatingsByUniqueKey(GetRatingUniqueKeyQuery getRatingUniqueKeyQuery);
        dynamic DeleteRating(DeleteRatingCommand command);
        dynamic UpdateRating(UpdateRatingCommand command);
        IDictionary<string, int> GetAverageRatings(IEnumerable<dynamic> ratings);
    }
}