using FluentValidation;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Database.Models.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator(ApplicationDbContext applicationDbContext)
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000);
        }
    }
}
