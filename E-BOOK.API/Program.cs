using E_BOOK.API.Repository;
using E_BOOK.API.Repository.Repository_Interface;
using E_BOOK.API.Service;
using E_BOOK.API.Service.Service_Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MODEL;
using MODEL.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<E_BookDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IGenerateJwt, GenerateJwt>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IE_BookRepository, E_BookRepository>();

builder.Services.AddDbContext<E_BookDbContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:ContactApiConnectionString"]));
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailService, EmailService>();
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password reset token options
//    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;

//    // Email sender options
//    options.SignIn.RequireConfirmedEmail = true;
//    options.User.RequireUniqueEmail = true;
//    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
//});

//builder.Services.AddTransient<IEmailSender, EmailConfiguration>();
//builder.Services.AddSingleton<SmtpClient>(provider =>
//{
//    var emailSettingsHost = builder.Configuration["EmailSettings:Host"];
//    var emailSettingsPort = builder.Configuration["EmailSettings:Port"];
//    var emailSettingsUsername = builder.Configuration["EmailSettings:UserName"];
//    var emailSettingsPassword = builder.Configuration["EmailSettings:Password"];
//    return new SmtpClient(emailSettingsHost, int.Parse(emailSettingsPort))
//    {
//        UseDefaultCredentials = false,
//        Credentials = new NetworkCredential(emailSettingsUsername, emailSettingsPassword),
//        EnableSsl = true
//    };
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
