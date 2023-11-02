using JWTTemplate.Models.ServiceModels;

namespace JWTTemplate.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> Register(User user);
        Task<User> Get(string login);
    }
}
