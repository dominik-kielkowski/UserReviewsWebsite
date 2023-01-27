using Microsoft.AspNetCore.Authorization;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserContextService _userContextService;

        public ReviewService(ApplicationDbContext db, IUserContextService userContextService)
        {
            _db = db;
            _userContextService = userContextService;
        }

        public IEnumerable<Review> GetReviews()
        {
            List<Review> reviews = _db.Reviews.ToList();

            if (reviews == null)
            {
                throw new NotFoundException("Reviews not found");
            }

            return reviews;
        }

        public IEnumerable<Review> GetReview(int id)
        {
            List<Review> reviews = _db.Reviews.Include(r => r.User).Where(x => x.ProductId == id).ToList();

            if (reviews == null)
            {
                throw new NotFoundException("Review not found");
            }

            return reviews;
        }

        public void AddReview(ReviewDto createReview)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == createReview.ProductId);

            User user = _db.Users.FirstOrDefault(p => p.Id == createReview.UserId);

            Review review = new Review
            {
                Title = createReview.Title,
                ReviewBody = createReview.ReviewBody,
                Score = createReview.Score,
                Product = product,
                User = user
            };

            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        public void UpdateReview(int id, ReviewDto updateReview)
        {
            int currentUserId = _userContextService.GetUserId;

            var review = _db.Reviews.Include(r => r.User).Where(review => review.User.Id == currentUserId).FirstOrDefault(review => review.Id == id);

            if (review == null)
            {
                throw new NotFoundException("Review inaccessible");
            }

            review.Title = updateReview.Title;
            review.ReviewBody = updateReview.ReviewBody;
            review.Score = updateReview.Score;

            _db.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            int currentUserId = _userContextService.GetUserId;

            var review = _db.Reviews.Include(r => r.User).Where(review => review.User.Id == currentUserId).FirstOrDefault(review => review.Id == id);

            if (review == null)
            {
                throw new NotFoundException("Review inaccessible ");
            }

            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }
    }
}
