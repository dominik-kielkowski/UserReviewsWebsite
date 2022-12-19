using RecipeBookAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _db;

        public ReviewService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Review> GetReviews()
        {
            List<Review> reviews = _db.Reviews.ToList();

            return reviews;
        }

        public Review GetReview(int id)
        {
            Review review = _db.Reviews.Find(id);

            return review;
        }

        public void AddReview(Review createReview)
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

        public void UpdateReview(int id, Review updateReview)
        {
            Review review = _db.Reviews.FirstOrDefault(p => p.Id == id);

            //Product product = _db.Products.FirstOrDefault(p => p.Id == updateReview.ProductId);
            //User user = _db.Users.FirstOrDefault(p => p.Id == updateReview.UserId);

            review.Title = updateReview.Title;
            review.ReviewBody = updateReview.ReviewBody;
            review.Score = updateReview.Score;
            //review.Product = product;
            //review.User = user;

            _db.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            Review review = _db.Reviews.FirstOrDefault(r => r.Id == id);

            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }
    }
}
