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
        dynamic GetRatingByUniqueKey(GetRatingUniqueKeyQuery getRatingUniqueKeyQuery);
        dynamic DeleteRating(DeleteRatingCommand command);
    }
}