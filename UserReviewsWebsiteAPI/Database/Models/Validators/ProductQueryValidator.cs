using FluentValidation;

namespace UserReviewsWebsiteAPI.Database.Models.Validators
{
    public class ProductQueryValidator : AbstractValidator<ProductQuery>
    {
        private string[] allowSortByColumnNames = { nameof(Product.Name), "Score" };
        public ProductQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).GreaterThanOrEqualTo(1);
            RuleFor(r => r.SortBy).Must(value => string.IsNullOrEmpty(value) || allowSortByColumnNames.Contains(value));
        }
    }
}
