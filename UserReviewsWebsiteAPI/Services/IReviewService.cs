using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IReviewService
    {
        void AddReview(Review createReview);
        void DeleteReview(int id);
        Review GetReview(int id);
        IEnumerable<Review> GetReviews();
        void UpdateReview(int id, Review updateReview);
    }
}