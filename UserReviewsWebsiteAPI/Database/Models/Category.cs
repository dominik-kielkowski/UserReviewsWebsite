using System.ComponentModel.DataAnnotations;

namespace UserReviewsWebsiteAPI.Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
