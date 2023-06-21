using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using MODEL.Entity;

namespace E_BOOK.API.Repository.Repository_Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUp);
        Task<string> LoginAsync(SignInModel signIn);
        Task<ImageUploadResult> UploadProfilePic(IFormFile file, string email);
        Task<bool> AddRoleAsync(string email, string Role);
        Task<bool> ForgotPassword(string email);
    }
}
