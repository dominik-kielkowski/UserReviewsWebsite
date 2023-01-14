namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AverageScore { get; set; }
    }
}
