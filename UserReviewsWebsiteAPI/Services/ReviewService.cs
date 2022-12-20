using Microsoft.AspNetCore.Authorization;
using RecipeBookAPI.Database.Data;
using UserReviewsWebsiteAPI.Authorization;
using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public ReviewService(ApplicationDbContext db, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _db = db;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
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

            User user = _db.Users.FirstOrDefault(p => p.Id == _userContextService.GetUserId);

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

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, review,
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new Exception("Unotharized");
            }

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

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, review,
               new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new Exception("Unotharized");
            }

            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }
    }
}
