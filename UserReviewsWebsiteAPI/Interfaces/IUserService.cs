using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUser(RegisterDto createUser);
        string GenerateJwt(LoginDto loginUser);
        Task<User> GetUser(string id);
    }
}