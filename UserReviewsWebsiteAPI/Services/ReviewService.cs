using Microsoft.AspNetCore.Authorization;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Interfaces;
using System.Collections.Generic;

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

        public async Task<IEnumerable<Review>> GetReviews()
        {
            var reviews = await _db.Reviews.ToListAsync();

            if (reviews == null)
            {
                throw new NotFoundException("Reviews not found");
            }

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviewsWithId(int id)
        {
            var review = await _db.Reviews.Include(r => r.User).Where(x => x.ProductId == id).ToListAsync();

            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

            return review;
        }

        public async Task<Review> AddReview(ReviewDto createReview)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(p => p.Id == createReview.ProductId);

            User user = await _db.Users.FirstOrDefaultAsync(p => p.Id == createReview.UserId);

            Review review = new Review
            {
                Title = createReview.Title,
                ReviewBody = createReview.ReviewBody,
                Score = createReview.Score,
                Product = product,
                User = user
            };

            await _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();

            return review;
        }

        public async Task<Review> UpdateReview(int id, ReviewDto updateReview)
        {
            int currentUserId = _userContextService.GetUserId;

            var review = await _db.Reviews.Include(r => r.User).Where(review => review.User.Id == currentUserId).FirstOrDefaultAsync(review => review.Id == id);

            if (review == null)
            {
                throw new NotFoundException("Review inaccessible");
            }

            review.Title = updateReview.Title;
            review.ReviewBody = updateReview.ReviewBody;
            review.Score = updateReview.Score;

            await _db.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteReview(int id)
        {
            int currentUserId = _userContextService.GetUserId;

            var review = await _db.Reviews.Include(r => r.User).Where(review => review.User.Id == currentUserId).FirstOrDefaultAsync(review => review.Id == id);

            if (review == null)
            {
                throw new NotFoundException("Review inaccessible ");
            }

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
            return review;
        }
    }
}
