using FluentValidation;
using UserReviewsWebsiteAPI.Database.Data;

namespace UserReviewsWebsiteAPI.Database.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(ApplicationDbContext applicationDbContext)
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3);

            RuleFor(x => x.Username).Custom((value, context) =>
            {
                var usernameInUse = applicationDbContext.Users.Any(u => u.Username == value);
                if (usernameInUse)
                {
                    context.AddFailure("Username", "That username is already taken");
                }
            });

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = applicationDbContext.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is already taken");
                }
            });

            RuleFor(x => x.PasswordHash).NotEmpty().MinimumLength(6);
        }
    }
}
