using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserReviewsWebsiteAPI.Database.Data;
using System.Text;
using UserReviewsWebsiteAPI.Authorization;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Middlewere;
using UserReviewsWebsiteAPI.Services;
using FluentValidation;
using UserReviewsWebsiteAPI.Database.Models.Validators;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Interfaces;
using UserReviewsWebsiteAPI.Dtos;
using UserReviewsWebsiteAPI.Seeders;
using UserReviewsWebsiteAPI.Settings;
using CloudinaryDotNet;
using UserReviewsWebsiteAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"));
});

// Enable CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                      });
});

AuthenticationSettings authenticationSettings = new AuthenticationSettings();
//Cloudinary cloudinary = new Cloudinary();

builder.Services.AddSingleton(authenticationSettings);

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
//builder.Configuration.GetSection("CloudinarySettings").Bind(cloudinary);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});



builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();

seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
