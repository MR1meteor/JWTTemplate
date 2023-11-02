using JWTTemplate.Data.Interfaces;
using JWTTemplate.Services.Interfaces;
using System.Security.Cryptography;
using JWTTemplate.Models.ServiceModels;
using JWTTemplate.Models.DbModels;

namespace JWTTemplate.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository userRepository;

        public IdentityService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> Get(string login)
        {
            
        }

        public async Task<bool> Register(User user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash);

            var dbUser = new DbUser
            {
                Login = user.Login,
                PasswordHash = passwordHash
            };

            return await userRepository.Add(dbUser);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
