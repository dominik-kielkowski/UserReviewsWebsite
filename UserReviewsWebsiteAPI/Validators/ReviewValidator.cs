using FluentValidation;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Database.Models.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator(ApplicationDbContext applicationDbContext)
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.ReviewBody).NotEmpty().MaximumLength(5000);
        }
    }
}
