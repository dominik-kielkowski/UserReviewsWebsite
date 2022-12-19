using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReviewBody { get; set; }
        [Range(1,10)]
        public int Score { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
