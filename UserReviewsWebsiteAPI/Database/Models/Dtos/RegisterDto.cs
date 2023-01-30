using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
