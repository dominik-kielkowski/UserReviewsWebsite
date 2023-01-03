using Microsoft.AspNetCore.Authorization;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Authorization;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

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

        public void AddReview(CreateReviewDto createReview)
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

            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

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

            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

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
