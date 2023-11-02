using Dapper;
using JWTTemplate.Data.Data;
using JWTTemplate.Data.Interfaces;
using JWTTemplate.Models.DbModels;

namespace JWTTemplate.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string TABLE_NAME = @"public.""Users""";
        private readonly DapperContext context;

        public async Task<bool> Add(DbUser user)
        {
            var query = $@"insert into {TABLE_NAME} ({nameof(DbUser.Login)}, {nameof(DbUser.PasswordHash)})
                            values (@login, @passwordHash)
                            returning *";

            var queryArgs = new { Login = user.Login, PasswordHash = user.PasswordHash };

            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<DbUser>(query, queryArgs);
                return result.Count() > 0;
            }
        }
    }
}
