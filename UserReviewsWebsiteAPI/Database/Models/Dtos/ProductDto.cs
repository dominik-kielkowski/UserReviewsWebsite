using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models.Dtos
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
