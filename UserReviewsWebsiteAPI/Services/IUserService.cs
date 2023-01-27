using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IUserService
    {
        void RegisterUser(RegisterDto createUser);
        string GenerateJwt(LoginDto loginUser);
        User GetUser(string id);
    }
}