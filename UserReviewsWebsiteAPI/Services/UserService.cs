using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UserReviewsWebsiteAPI.Database.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Exceptions;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

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

        public IEnumerable<User> GetUsers()
        {
            List<User> users = _db.Users.ToList();

            if (users == null)
            {
                throw new NotFoundException("Users not found");
            }

            return users;
        }

        public User GetUser(string id)
        {
            int userId = Convert.ToInt32(id);
            User user = _db.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }

        public string GenerateJwt(LoginDto loginUser)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == loginUser.Email);

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.PasswordHash);
            if(result == PasswordVerificationResult.Failed)
            {
                throw (new WrongPasswordException("Incorrect password"));
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username.ToString())
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

        public void RegisterUser(RegisterDto createUser)
        {
            User user = new User
            {
                Username = createUser.Username,
                Email = createUser.Email,
                DateOfBirth = createUser.DateOfBirth,
                Nationality = createUser.Nationality
            };

            var hashedPassword = _passwordHasher.HashPassword(user, createUser.PasswordHash);

            user.PasswordHash = hashedPassword;

            _db.Users.Add(user);
            _db.SaveChanges();

        }

        public void UpdateUser(int id, User updateUser)
        {
            User user = _db.Users.FirstOrDefault(r => r.Id == id);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            user.Username = updateUser.Username;

            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = _db.Users.FirstOrDefault(r => r.Id == id);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
        }


    }
}
