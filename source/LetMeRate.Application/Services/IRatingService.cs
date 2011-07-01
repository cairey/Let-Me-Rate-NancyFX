using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IRatingService
    {
        void AddRating(AddRatingCommand addRatingCommand);
        dynamic GetAllRatings(GetAllRatingsQuery getAllRatingsQuery);
    }
}