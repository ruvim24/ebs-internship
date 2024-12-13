namespace API.SignalR;

public class ConnectionMapping
{
    private readonly Dictionary<int, string> _connections = new();
    private readonly object _lock = new object();

    public void AddConnection(int userId, string connectionId)
    {
        lock (_lock)
        {
            _connections[userId] = connectionId;
        }
    }

    public void RemoveConnection(string connectionId)
    {
        lock (_lock)
        {
            var entry = _connections.FirstOrDefault(x => x.Value == connectionId);
            if (entry.Key != 0)
            {
                _connections.Remove(entry.Key);
            }
        }
    }

    public string? GetConnection(int userId)
    {
        lock (_lock)
        {
            _connections.TryGetValue(userId, out var connectionId);
            return connectionId;
        }
    }
}
