using E_BOOK.API.Repository.Repository_Interface;
using E_BOOK.API.Service;
using E_BOOK.API.Service.Service_Interface;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entity;

namespace E_BOOK.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailService _emailService;

        public AccountController(IAccountRepository accountRepository, IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _emailService = emailService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            try
            {
                 var result = await _accountRepository.SignUpAsync(signUp);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            try
            {
                var result = await _accountRepository.LoginAsync(signInModel);
                if (string.IsNullOrEmpty(result))
                {
                    return Unauthorized(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex);
            }

        }
        [HttpPatch("upload")]
        public async Task<IActionResult> UploadProfilePictureAsync(IFormFile file, string email)
        {
            try
            {
                var result = await _accountRepository.UploadProfilePic(file, email);
                return Ok(new
                {
                    PublicId = result.PublicId,
                    Url = result.SecureUrl.ToString(),
                    Status = "Uploaded Succefully"
                });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Uploading Image to the database");
            }
        }
        [HttpGet]
        public async Task<IActionResult> TestEmail()
        {
            var message = new Message(new string[] { "bsaheed79@gmail.com" }, "Test", "<h1>I am testing email sending</h1>");

            _emailService.SendEmail(message);
            return StatusCode(StatusCodes.Status200OK, new { Status = "Sucess", Message = "Email Sent Successfully" });
        }
        [HttpPatch("UpdateRole")]
        public async Task<IActionResult> UpdateRoleAsync(string email, string role)
        {
            try
            {
                var UpdateRole = await _accountRepository.AddRoleAsync(email, role);
                if (UpdateRole)
                {
                    return Ok(new { Message = "Role updated successfully", StatusCode = StatusCodes.Status200OK });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error  Image to the database");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error  Image to the database");
            }
        }

    }
}
