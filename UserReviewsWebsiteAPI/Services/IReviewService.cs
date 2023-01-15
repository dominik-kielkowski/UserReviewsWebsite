using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IReviewService
    {
        void AddReview(ReviewDto createReview);
        void DeleteReview(int id);
        IEnumerable<Review> GetReview(int id);
        IEnumerable<Review> GetReviews();
        void UpdateReview(int id, ReviewDto updateReview);
    }
}