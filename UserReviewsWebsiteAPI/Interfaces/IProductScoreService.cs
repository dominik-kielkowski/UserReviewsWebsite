namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IProductScoreService
    {
        Task<double> GetAveregeScore(int productId);
    }
}