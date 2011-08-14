using System.Collections.Generic;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IRatingService
    {
        dynamic AddRating(AddRatingCommand command);
        dynamic GetAllRatings(GetAllRatingsQuery query);
        dynamic GetRatingsBetweenRating(GetRatingsBetweenRatingQuery query);
        dynamic GetRatingsByCustomParam(GetRatingsCustomParamQuery query);
        dynamic GetRatingsByUniqueKey(GetRatingUniqueKeyQuery query);
        dynamic DeleteRating(DeleteRatingCommand command);
        dynamic UpdateRating(UpdateRatingCommand command);
        IDictionary<string, int> GetAverageRatings(IEnumerable<dynamic> ratings);
    }
}