using LoginToTheVoid.Abstractions;
using Npgsql;

namespace LoginToTheVoid;

internal class UserCollection(Connector connector) : DataCollection<User>(connector)
{
    public override string GetQueryString()
    {
        string query = @"
            SELECT user_id,
                   name,
                   password_hash,
                   password_salt
            FROM users
        ";
        if (Parameters.ContainsKey("name"))
        {
            query += "\nWHERE name ilike @name";
        }
        return query;
    }

    public void WhereNameEquals(string name)
    {
        Parameters["name"] = name;
    }

    public override void HandleRowLoad(NpgsqlDataReader reader)
    {
        var row = new User
        {
            UserId = reader.GetInt32(0),
            Name = reader.GetString(1),
            PasswordHash = reader.IsDBNull(2) ? null : reader.GetString(2),
            PasswordSalt = reader.IsDBNull(3) ? null : reader.GetString(3),
        };
        Add(row);
    }
}
