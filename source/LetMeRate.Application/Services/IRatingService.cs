using LetMeRate.Application.Commands;

namespace LetMeRate.Application.Services
{
    public interface IRatingService
    {
        void AddRating(AddRatingCommand addRatingCommand);
    }
}