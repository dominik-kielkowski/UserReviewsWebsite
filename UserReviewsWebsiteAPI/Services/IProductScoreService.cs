namespace UserReviewsWebsiteAPI.Services
{
    public interface IProductScoreService
    {
        Task<double> GetAveregeScore(int productId);
    }
}