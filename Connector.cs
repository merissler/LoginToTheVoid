using Npgsql;

namespace LoginToTheVoid;

public class Connector(string host, string database, string user, string password)
{
    public string Host { get; } = host;
    public string Database { get; } = database;
    public string User { get; } = user;
    public string Password { get; } = password;

    public async Task<NpgsqlConnection> GetOpenConnAsync()
    {
        var builder = new NpgsqlConnectionStringBuilder()
        {
            Host = Host,
            Database = Database,
            Username = User,
            Password = Password,
        };
        var conn = new NpgsqlConnection(builder.ConnectionString);
        await conn.OpenAsync();
        return conn;
    }
}
