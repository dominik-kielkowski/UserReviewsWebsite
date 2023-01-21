using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI
{
    public class RoleSeeder
    {
        private readonly ApplicationDbContext _db;
        public RoleSeeder(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Seed()
        {
            if (_db.Database.CanConnect())
            {
                if (!_db.Role.Any())
                {
                    var roles = GetRoles();
                    _db.Role.AddRange(roles);
                }
                _db.SaveChanges();
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },

                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
    }
}
