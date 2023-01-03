namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class CreateReviewDto
    {
        public string Title { get; set; }
        public string ReviewBody { get; set; }
        public int Score { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
