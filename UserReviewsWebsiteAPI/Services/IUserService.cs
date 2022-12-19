using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IUserService
    {
        void RegisterUser(User createUser);
        string GenerateJwt(User loginUser);
        void DeleteUser(int id);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        void UpdateUser(int id, User updateUser);
    }
}