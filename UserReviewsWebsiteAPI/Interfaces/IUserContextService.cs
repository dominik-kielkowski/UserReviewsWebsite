using System.Security.Claims;

namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IUserContextService
    {
        int GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}