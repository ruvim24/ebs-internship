using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR;
using Microsoft.AspNetCore.SignalR;

public class NotificationHub : Hub
{
    private readonly ConnectionMapping _connectionMapping;

    public NotificationHub(ConnectionMapping connectionMapping)
    {
        _connectionMapping = connectionMapping;
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");

        var userIdClaim = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            _connectionMapping.AddConnection(userId, Context.ConnectionId);
            Console.WriteLine($"UserId {userId} mapped to connection {Context.ConnectionId}");
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}");

        _connectionMapping.RemoveConnection(Context.ConnectionId);

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendNotificationToUser(int userId, string message)
    {
        var connectionId = _connectionMapping.GetConnection(userId);

        if (connectionId != null)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
            Console.WriteLine($"Sent message to userId {userId}: {message}");
        }
        else
        {
            Console.WriteLine($"No connection found for userId {userId}");
        }
    }
    public async Task SendToAll(string message)
    {
        try
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
            Console.WriteLine($"Mesage send to all {message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}


