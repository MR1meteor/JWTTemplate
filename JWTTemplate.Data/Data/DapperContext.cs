using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace JWTTemplate.Data.Data
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("PostgresqlConnection");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);
    }
}
