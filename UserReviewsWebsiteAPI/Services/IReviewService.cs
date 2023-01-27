using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IReviewService
    {
        Task AddReview(ReviewDto createReview);
        Task DeleteReview(int id);
        Task<IEnumerable<Review>> GetReview(int id);
        Task<IEnumerable<Review>> GetReviews();
        Task UpdateReview(int id, ReviewDto updateReview);
    }
}