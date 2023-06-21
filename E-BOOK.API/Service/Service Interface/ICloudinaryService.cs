using CloudinaryDotNet.Actions;

namespace E_BOOK.API.Service.Service_Interface
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadPhoto(IFormFile file, object id);
    }
}
