using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using E_BOOK.API.Repository.Repository_Interface;
using E_BOOK.API.Service;
using E_BOOK.API.Service.Service_Interface;
using Microsoft.AspNetCore.Identity;

using MODEL.Entity;

namespace E_BOOK.API.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenerateJwt _generateJwt;
        private readonly ICloudinaryService _cloudinaryService;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IGenerateJwt generateJwt, ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration ?? throw new ArgumentNullException();
            _roleManager = roleManager;
            _generateJwt = generateJwt;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IdentityResult> SignUpAsync(SignUp signUp)
        {
            var existUser = await _userManager.FindByEmailAsync(signUp.Email);
            if (existUser != null)
            {
                throw new Exception("User already exists");
            }

            if (await _roleManager.RoleExistsAsync("USER"))
            {
                var user = new AppUser()
                {
                    FirstName = signUp.FirstName,
                    LastName = signUp.LastName,
                    Email = signUp.Email,
                    UserName = signUp.Email,
                    PhoneNumber = signUp.PhoneNumber,
                    ProfilePicture = string.Empty,
                    Gender = signUp.Gender,

                };
                var result = await _userManager.CreateAsync(user, signUp.Password);
                if (!result.Succeeded)
                {

                    throw new Exception("User failed to create");
                }
                await _userManager.AddToRoleAsync(user, "USER");
                return result;
            }
            else
            {
                throw new Exception("This role does not exist");
            }

        }
        public async Task<string> LoginAsync(SignInModel signIn)
        {
            var user = await _userManager.FindByEmailAsync(signIn.Email);
            if (user == null)
            {
                throw new Exception("Email does not exist");
            }
            if (!await _userManager.CheckPasswordAsync(user, signIn.Password))
            {
                throw new Exception("Invalid password");
            }
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, isPersistent: false, lockoutOnFailure: false);

            var generateToken = await _generateJwt.GenerateToken(user, signIn.Email);
            if (result.Succeeded)
            {
                return generateToken;
            }
            throw new Exception("Registration not successful");
        }

        public async Task<ImageUploadResult> UploadProfilePic(IFormFile file, string email)
        {
            var findUser = await _userManager.FindByEmailAsync(email);
            if (findUser == null)
            {
                throw new Exception("Account to upload Profile Picture for not found");
            }
            var uploadImageResult = await _cloudinaryService.UploadPhoto(file, findUser);
            if (uploadImageResult == null)
            {
                throw new Exception("Image not uploaded successfully");
            }
            findUser.ProfilePicture = uploadImageResult.Url.ToString();
            var updateUserImg = await _userManager.UpdateAsync(findUser);
            if (updateUserImg.Succeeded)
            {
                return uploadImageResult;
            }
            throw new Exception("Contact details not updated successfully");
        }

        public async Task<bool> AddRoleAsync(string email, string Role)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                throw new Exception("The user to update role for not exist");
            }
            var existingRoles = await _userManager.GetRolesAsync(existingUser);
            var RemoveExistingRole = await _userManager.RemoveFromRolesAsync(existingUser, existingRoles);
            if (await _roleManager.RoleExistsAsync(Role))
            {
                var AddRole = _userManager.AddToRoleAsync(existingUser, Role);
                if (AddRole.IsCompletedSuccessfully)
                {
                    return true;
                }
                throw new Exception("Error Updating Role");
            }
            throw new Exception("These row does not exist");
        }

        public Task<bool> ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}

