using Npgsql;

namespace Advocacia_Api.Context;

public class DbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public NpgsqlConnection GetConnection() =>
        new (_configuration.GetConnectionString("postgres"));
}

