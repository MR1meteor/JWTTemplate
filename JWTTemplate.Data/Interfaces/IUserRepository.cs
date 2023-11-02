using JWTTemplate.Models.DbModels;

namespace JWTTemplate.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Add(DbUser user);
    }
}
