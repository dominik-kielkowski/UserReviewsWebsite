using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterDto createUser);
        Task<string> GenerateJwt(LoginDto loginUser);
        Task<User> GetUser(string id);
    }
}