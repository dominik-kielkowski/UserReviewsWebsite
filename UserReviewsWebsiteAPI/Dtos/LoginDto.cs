using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
