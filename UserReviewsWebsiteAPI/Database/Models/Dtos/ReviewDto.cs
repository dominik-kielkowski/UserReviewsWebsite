using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class ReviewDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ReviewBody { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
