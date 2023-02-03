using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IReviewService
    {
        Task<Review> AddReview(ReviewDto createReview);
        Task<Review> DeleteReview(int id);
        Task<IEnumerable<Review>> GetReviewsWithId(int id);
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> UpdateReview(int id, ReviewDto updateReview);
    }
}