using Npgsql;

namespace LoginToTheVoid.Abstractions;

public abstract class DataCollection<T>(Connector connector) : List<T>
{
    public Dictionary<string, object> Parameters { get; } = [];

    protected readonly Connector _connector = connector;
    protected readonly HashSet<int> _added = [];
    protected readonly HashSet<int> _removed = [];

    public abstract string GetQueryString();
    public abstract void HandleRowLoad(NpgsqlDataReader reader);

    public async Task LoadAsync()
    {
        Clear();
        _added.Clear();
        _removed.Clear();

        using var conn = await _connector.GetOpenConnAsync();

        using var query = conn.CreateCommand();
        query.CommandText = GetQueryString();
        foreach (var p in Parameters) query.Parameters.AddWithValue(p.Key, p.Value);

        using var reader = query.ExecuteReader();
        while (await Task.Run(reader.Read)) HandleRowLoad(reader);
    }
}
