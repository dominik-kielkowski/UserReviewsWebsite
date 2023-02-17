using CloudinaryDotNet.Actions;

namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}
