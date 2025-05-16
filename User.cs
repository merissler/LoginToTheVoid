namespace LoginToTheVoid;

internal class User
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }

    public async Task InsertAsync(Connector connector)
    {
        using var conn = await connector.GetOpenConnAsync();

        using var command = conn.CreateCommand();
        command.CommandText = @"
            INSERT INTO users (
                name,
                password_hash,
                password_salt
            ) VALUES (
                @name,
                @password_hash,
                @password_salt
            ) RETURNING user_id
        ";
        command.Parameters.AddWithValue("name", Name);
        if (PasswordHash is null) command.Parameters.AddWithValue("password_hash", DBNull.Value);
        else command.Parameters.AddWithValue("password_hash", PasswordHash);
        if (PasswordSalt is null) command.Parameters.AddWithValue("password_salt", DBNull.Value);
        else command.Parameters.AddWithValue("password_salt", PasswordSalt);

        int id = Convert.ToInt32(await command.ExecuteScalarAsync());
        UserId = id;
    }
}
