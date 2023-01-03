namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
    }
}
