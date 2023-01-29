using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UserReviewsWebsiteAPI.Database.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Exceptions;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace UserReviewsWebsiteAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(ApplicationDbContext db, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _db = db;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<User> GetUser(string id)
        {
            int userId = Convert.ToInt32(id);
            User user = await _db.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }

        public string GenerateJwt(LoginDto loginUser)
        {
            var user = _db.Users.Include(x => x.Role).FirstOrDefault(u => u.Email == loginUser.Email && u.Username == loginUser.Username);

            if(user == null)
            {
                throw (new WrongPasswordException("Incorrect login details"));
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.PasswordHash);
            if(result == PasswordVerificationResult.Failed)
            {
                throw (new WrongPasswordException("Incorrect password"));
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterDto createUser)
        {
            Role role = await _db.Role.FirstOrDefaultAsync(r => r.Id == createUser.RoleId);


            User user = new User
            {
                Username = createUser.Username,
                Email = createUser.Email,
                Role = role
            };

            if (user == null){
                throw (new WrongPasswordException("Incorrect password"));
            }

            var hashedPassword = _passwordHasher.HashPassword(user, createUser.PasswordHash);

            user.PasswordHash = hashedPassword;

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}
