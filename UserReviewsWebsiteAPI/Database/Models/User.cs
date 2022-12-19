using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string PasswordHash { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
