using System.Security.Claims;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IUserContextService
    {
        int GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}