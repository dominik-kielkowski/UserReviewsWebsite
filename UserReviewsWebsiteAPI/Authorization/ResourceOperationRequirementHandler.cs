using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Review>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Review review)
        {
            if(requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            string userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if(review.UserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
