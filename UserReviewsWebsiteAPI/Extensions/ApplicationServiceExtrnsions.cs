using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using UserReviewsWebsiteAPI.Authorization;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Database.Models.Validators;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Dtos;
using UserReviewsWebsiteAPI.Interfaces;
using UserReviewsWebsiteAPI.Middlewere;
using UserReviewsWebsiteAPI.Seeders;
using UserReviewsWebsiteAPI.Services;
using FluentValidation.AspNetCore;

namespace UserReviewsWebsiteAPI.Extensions
{
    public static class ApplicationServiceExtrnsions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddControllers().AddFluentValidation();
            services.AddScoped<RoleSeeder>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IProductScoreService, ProductScoreService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterDto>, UserValidator>();
            services.AddScoped<IValidator<ReviewDto>, ReviewValidator>();
            services.AddScoped<IValidator<ProductDto>, ProductValidator>();
            services.AddScoped<IValidator<ProductQuery>, ProductQueryValidator>();
            services.AddHttpContextAccessor();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            return services;
        }
    }
}
